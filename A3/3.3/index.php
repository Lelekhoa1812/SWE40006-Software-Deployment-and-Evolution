<?php
// Core calculator function
function calc($a, $b, $op) {
  switch ($op) {
    case 'add': return $a + $b;
    case 'sub': return $a - $b;
    case 'mul': return $a * $b;
    case 'div': return $b == 0 ? 'Division by zero' : $a / $b;
    default: return 'Unknown operation';
  }
}

$result = '';
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
  $a = floatval($_POST['a'] ?? 0);
  $b = floatval($_POST['b'] ?? 0);
  $op = $_POST['op'] ?? 'add';
  $result = calc($a, $b, $op);
}
?>
<!doctype html>
<html>
<head>
  <meta charset="utf-8">
  <title>PHP Calculator</title>
  <style>
    body {
      font-family: Arial, sans-serif;
      background: #f5f6fa;
      display: flex;
      justify-content: center;
      align-items: center;
      height: 100vh;
    }
    .calculator {
      background: #fff;
      padding: 30px;
      border-radius: 12px;
      box-shadow: 0 8px 16px rgba(0,0,0,0.1);
      text-align: center;
      width: 320px;
    }
    h1 {
      font-size: 1.5rem;
      margin-bottom: 20px;
      color: #2f3640;
    }
    input, select, button {
      font-size: 1rem;
      padding: 8px 10px;
      margin: 6px;
      border: 1px solid #dcdde1;
      border-radius: 6px;
      outline: none;
    }
    button {
      background: #273c75;
      color: #fff;
      cursor: pointer;
      transition: background 0.3s;
    }
    button:hover {
      background: #40739e;
    }
    .result {
      margin-top: 15px;
      font-size: 1.2rem;
      color: #44bd32;
      font-weight: bold;
    }
  </style>
</head>
<body>
  <div class="calculator">
    <h1>PHP Calculator</h1>
    <form method="post">
      <input name="a" step="any" type="number" placeholder="Enter first number" required>
      <br>
      <select name="op">
        <option value="add">+</option>
        <option value="sub">−</option>
        <option value="mul">×</option>
        <option value="div">÷</option>
      </select>
      <br>
      <input name="b" step="any" type="number" placeholder="Enter second number" required>
      <br>
      <button type="submit">Calculate</button>
    </form>
    <?php if ($result !== ''): ?>
      <div class="result">Result: <?= htmlspecialchars((string)$result) ?></div>
    <?php endif; ?>
  </div>
</body>
</html>
