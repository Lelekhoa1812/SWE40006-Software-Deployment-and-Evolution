title Medical Messenger – Eraser Workflow (Client | App | Data | 
Observability | CI|CD | Security | Infra)

// ---------- Semantic Color Key ----------
// Legend [color: slate, icon: info] {
//   Client color = lightblue
//   Application (Next.js Monolith) color = green
//   Data | Secrets color = purple
//   Observability color = magenta
//   CI|CD | Environments color = orange
//   Security | Privacy color = red
//   Infrastructure color = charcoal
//   Data Model (MVP) color = gray
// }

// ---------- Client ----------
Client [color: lightblue, icon: monitor] {
  Patient | Doctor Browser [icon: user, color: lightblue, label:"Next.js 
SPA UI | shadcn|ui | Tailwind"]
}

// ---------- Application (Next.js Monolith on Azure App Service) 
----------
Application [color: green, icon: server] {
  Next.js Server [icon: server, color: green, label:"Pages | API Routes | 
SSR"]
  Socket.IO Gateway [icon: rss, color: green, label:"WebSockets | presence 
| delivery status"]
  Auth Service [icon: key, color: green, label:"email | password | bcrypt 
| sessions"]
  Directory Service [icon: search, color: green, label:"doctor search | 
specialty filter"]
  Subscription Service [icon: user-check, color: green, label:"request | 
approve | deny"]
  Messaging Service [icon: message-square, color: green, label:"1:1 
threads | persistence"]
  Config Loader [icon: settings, color: green, label:"app settings | KV 
references"]
}

// ---------- Data | Secrets ----------
Data | Secrets [color: purple, icon: database] {
  MongoDB Atlas [icon: database, color: purple, label:"users | doctors | 
subscriptions | messages"]
  Azure Key Vault [icon: lock, color: purple, label:"Mongo URI | session 
secret"]
}

// ---------- Observability ----------
Observability [color: magenta, icon: activity] {
  Application Insights [icon: eye, color: magenta, label:"traces | metrics 
| dashboards | alerts"]
}

// ---------- CI|CD | Environments ----------
CI|CD | Environments [color: orange, icon: git-branch] {
//   GitHub Actions CI [icon: play, color: orange, label:"build | lint | 
test"]
//   Staging Slot [icon: beaker, color: orange, label:"pre-prod | sticky 
sessions"]
//   Smoke Tests [icon: check-circle, color: orange, label:"basic flows | 
telemetry sanity"]
//   Production Slot [icon: rocket, color: orange, label:"swap after 
approval"]
//   Branching Model [icon: git-commit, color: orange, label:"main | 
develop | feature PRs"]
}

// ---------- Security | Privacy ----------
Security | Privacy [color: red, icon: shield] {
  Password Policy [icon: shield-check, color: red, label:"bcrypt | never 
plaintext"]
  Transport TLS [icon: lock, color: red, label:"HTTPS | WSS enforced"]
  Access Control [icon: aws-guardduty, color: red, label:"role guard 
patient|doctor | subscription-gated chat"]
  Consent Notice [icon: file-check, color: red, label:"pairing consent | 
AU health privacy"]
  Future Hardening [icon: key, color: red, label:"optional app-layer 
encryption AES-GCM"]
}

// ---------- Data Model (MVP) ----------
Data Model (MVP) [color: gray, icon: file-text] {
  users [icon: user, color: gray, label:"email | password_hash | role | 
created_at"]
  doctors [icon: stethoscope, color: gray, label:"user_id | specialties[] 
| bio | status"]
  subscriptions [icon: users, color: gray, label:"patient_id | doctor_id | 
status | created_at"]
  messages [icon: message-circle, color: gray, label:"from_id | to_id | 
subscription_id | body | timestamps"]
}

// ---------- Flows ----------
// Client → App
Patient | Doctor Browser > Next.js Server: HTTPS
Patient | Doctor Browser > Socket.IO Gateway: WS | WSS

// App → Data | Secrets
Next.js Server > MongoDB Atlas: CRUD | users | doctors | subscriptions
Messaging Service > MongoDB Atlas: persist | messages
Auth Service > Azure Key Vault: read | secrets
Config Loader > Azure Key Vault: resolve | references

// App → Observability
Next.js Server > Application Insights: logs | traces | metrics
Socket.IO Gateway > Application Insights: events | connection stats
Messaging Service > Application Insights: custom events message_sent | 
message_received

// CI|CD → App Service Slots
// Branching Model > GitHub Actions CI: PR | push
// GitHub Actions CI > Staging Slot: deploy | develop
// Staging Slot > Smoke Tests: run | validate
// Smoke Tests > Production Slot: approval | swap

// Infra hosting relationships
Azure App Service.link string = "Azure App Service (Linux)"
Azure App Service (Linux) [color: charcoal, icon: cloud] {
  App Service Plan [icon: boxes, color: charcoal, label:"scale out | 
sticky sessions for WebSockets"]
}
App Service Plan > Application: hosts
App Service Plan > Observability: connects | auto-instrument
App Service Plan > Data | Secrets: VNet | outbound
App Service Plan > CI|CD | Environments: slots | swap

// Security posture in flow
Patient | Doctor Browser > Transport TLS: encrypted | channel
Auth Service > Password Policy: hash | verify
Next.js Server > Access Control: authorize | route guard
Subscription Service > Access Control: gate chat on approved

// Data Model linkages
Next.js Server > users
Directory Service > doctors
Subscription Service > subscriptions
Messaging Service > messages

// Monitoring & alerts
Application Insights > CI|CD | Environments: dashboards | alert rules

// Notes (attributes for clarity)
Socket.IO Gateway.attr string = "enable sticky sessions when scaling out"
MongoDB Atlas.attr string = "M0 dev | scale to paid when needed"
Application Insights.attr string = "p95 target < 400 ms in-region"

