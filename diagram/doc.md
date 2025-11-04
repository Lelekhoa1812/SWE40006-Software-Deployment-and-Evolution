title Medical Messenger – System Architecture & Deployment (Privacy by Design)

// ---------- Users ----------
Users [color: orange, icon: users] {
UserPatient [icon: user, color: orange]
UserDoctor [icon: stethoscope, color: orange]
UserAdmin [icon: shield, color: orange]
}

// ---------- Frontend ----------
Frontend [color: blue, icon: monitor] {
NextJSApp [icon: globe, color: blue, label:"Next.js 14"]
UIKit [icon: layout, color: blue, label:"shadcn ui + Tailwind"]
AuthContext [icon: key, color: blue]
Subscription Context [icon: users, color: blue]
Socket Context [icon: message-circle, color: blue]
FormsValidation [icon: file-check, color: blue, label:"RHF + Zod"]
ApiClient [icon: plug, color: blue]
WebVitals [icon: activity, color: blue]
}

// ---------- Contracts & Types ----------
Contracts [color: teal, icon: file-check] {
ZodSchemas [icon: file-check, color: teal, label:"DTOs + Env"]
SharedTypes [icon: type, color: teal, label:"shared types"]
}

// ---------- Backend ----------
Backend [color: purple, icon: server] {
FastifyServer [icon: server, color: purple, label:"HTTP + Logs"]
RouteAuth [icon: lock, color: purple, label:"auth routes"]
RouteDoctors [icon: id-card, color: purple, label:"doctor routes"]
RouteSubscriptions [icon: user-plus, color: purple, label:"subscription routes"]
RouteMessages [icon: message-square, color: purple, label:"message routes"]
RouteAdminAudit [icon: shield-check, color: purple, label:"audit routes"]
HealthEndpoint [icon: heartbeat, color: purple, label:"health"]
SocketIOServer [icon: radio, color: purple, label:"realtime"]
MiddlewareSession [icon: cookie, color: purple, label:"sessions"]
MiddlewareAuthGuard [icon: user-check, color: purple, label:"auth guard"]
MiddlewareAccessControl [icon: eye-off, color: purple, label:"chat access"]
MiddlewareAuditWriter [icon: file-text, color: purple, label:"audit writer"]
RetentionJob [icon: clock, color: purple, label:"retention"]
}

// ---------- Data Layer ----------
DataLayer [color: green, icon: database] {
MongoDB [icon: database, color: green]
Users Collection [icon: user, color: green]
Doctors Collection [icon: stethoscope, color: green]
Subscriptions Collection [icon: users, color: green]
Messages Collection [icon: message-square, color: green]
Audit Collection [icon: file-text, color: green]
Dao Users [icon: package, color: green]
Dao Doctors [icon: package, color: green]
Dao Subscriptions [icon: package, color: green]
Dao Messages [icon: package, color: green]
}

// ---------- Security ----------
Security [color: red, icon: lock] {
PasswordHashing [icon: key, color: red, label:"bcrypt"]
CORSPolicy [icon: lock, color: red, label:"allowed origins"]
RateLimitHeaders [icon: shield, color: red, label:"limits + headers"]
}

// ---------- Observability ----------
Observability [color: yellow, icon: activity] {
AppInsights [icon: activity, color: yellow]
PinoLogs [icon: file-text, color: yellow]
}

// ---------- Infrastructure ----------
Infrastructure [color: gray, icon: cloud] {
AppServiceStaging [icon: cloud, color: gray, label:"staging slot"]
AppServiceProduction [icon: cloud, color: gray, label:"production slot"]
KeyVault [icon: lock, color: gray, label:"secrets"]
BicepIaC [icon: code, color: gray, label:"infra templates"]
}

// ---------- CICD ----------
CICD [color: pink, icon: settings] {
GitHub Actions [icon: settings, color: pink]
Job Lint Type Test [icon: check-circle, color: pink]
Job Infra Lint [icon: code, color: pink]
Job Build Artifacts [icon: package, color: pink]
Job Deploy Staging [icon: upload, color: pink]
Job Smoke E2E [icon: zap, color: pink]
Job Manual Approval [icon: thumbs-up, color: pink]
JobSlotSwap [icon: repeat, color: pink, label:"swap"]
JobRollbackSwap [icon: rotate-ccw, color: pink, label:"rollback"]
}

// ---------- Flows: Users ----------
UserPatient > NextJSApp: browse login subscribe chat
UserDoctor > NextJSApp: review requests chat
UserAdmin > NextJSApp: view audits
NextJSApp <> AuthContext: credential validation
NextJSApp <> Subscription Context: retrieve valid subscription

// ---------- Flows: Frontend ↔ Contracts ----------
NextJSApp > FormsValidation: client checks
FormsValidation > ZodSchemas: shared rules
NextJSApp > ApiClient: fetch
ApiClient > FastifyServer: https requests
SharedTypes > NextJSApp: types
SharedTypes > FastifyServer: types
ZodSchemas > FastifyServer: server validation

// ---------- Flows: Backend Request Path ----------
FastifyServer > MiddlewareSession: resolve session
FastifyServer > MiddlewareAuthGuard: attach user

RouteAuth > Dao Users: user ops
RouteDoctors > Dao Doctors: search page
RouteSubscriptions > Dao Subscriptions: create approve deny
RouteMessages > Dao Messages: list create
RouteAdminAudit > Audit Collection: query audits

Dao Users > Users Collection: read write
Dao Doctors > Doctors Collection: read write
Dao Subscriptions > Subscriptions Collection: read write
Dao Messages > Messages Collection: read write

Users Collection > RouteAuth: user profile
Doctors Collection > RouteDoctors: doctor list
Subscriptions Collection > RouteSubscriptions: subscription state
Messages Collection > RouteMessages: message history

MiddlewareAuditWriter > Audit Collection: append event

// ---------- Flows: Realtime ----------
Socket Context > SocketIOServer: connect
SocketIOServer > MiddlewareAccessControl: verify pair
Socket Context > SocketIOServer: joinRoom
SocketIOServer > Messages Collection: persist message
SocketIOServer > NextJSApp: messageReceived

// ---------- Flows: Security & Privacy ----------
PasswordHashing > Users Collection: store hashes
PasswordHashing > Doctors Collection: store hashes
CORSPolicy > FastifyServer: restrict origins
RateLimitHeaders > FastifyServer: protect api
RetentionJob > Messages Collection: purge messages
RetentionJob > Audit Collection: purge audits

// ---------- Flows: Observability ----------
FastifyServer > AppInsights: traces metrics exceptions
NextJSApp > AppInsights: web vitals
PinoLogs > AppInsights: custom events

// ---------- Flows: CICD & Infra ----------
GitHub Actions > Job Lint Type Test: quality gates
GitHub Actions > Job Infra Lint: bicep build
GitHub Actions > Job Build Artifacts: bundles
GitHub Actions > Job Deploy Staging: deploy
Job Deploy Staging > AppServiceStaging: zip deploy
KeyVault > AppServiceStaging: secret refs
Job Smoke E2E > AppServiceStaging: health e2e
Job Manual Approval > JobSlotSwap: approve swap
JobSlotSwap > AppServiceProduction: go live
JobRollbackSwap > AppServiceProduction: revert

// ---------- Flows: Infra Telemetry ----------
AppServiceStaging > AppInsights: platform telemetry
AppServiceProduction > AppInsights: platform telemetry

// ---------- Cross-links ----------
NextJSApp > UIKit: components
NextJSApp > WebVitals: report
FastifyServer > HealthEndpoint: status check
BicepIaC > AppServiceStaging: provision
BicepIaC > AppServiceProduction: provision
BicepIaC > KeyVault: provision
BicepIaC > AppInsights: provision
