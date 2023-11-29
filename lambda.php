код от гпт для веба
index.php

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Login</title>
</head>
<body>
    <h2>Login</h2>
    <form action="login.php" method="post">
        <label for="username">Username:</label>
        <input type="text" id="username" name="username" required><br>

        <label for="password">Password:</label>
        <input type="password" id="password" name="password" required><br>

        <button type="submit">Login</button>
    </form>
</body>
</html>
login.php
<?php // Проверка, что форма была отправлена if ($_SERVER["REQUEST_METHOD"] == "POST") { // Получение введенных данных $username = $_POST["username"]; $password = $_POST["password"]; // Проверка учетных данных администратора if ($username === "admin" && $password === "admin") { // Успешная авторизация header("Location: admin_panel.php"); exit(); } else { // Неправильные учетные данные echo "Invalid username or password"; } } ?>
admin_panel.php
<?php
session_start();

// Проверка, что пользователь авторизован
if (!isset($_SESSION["username"]) || $_SESSION["username"] !== "admin") {
    header("Location: index.php");
    exit();
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Admin Panel</title>
</head>
<body>
    <h2>Welcome, Admin!</h2>
    <!-- Здесь можно добавить отображение информации о заказах -->
    <a href="logout.php">Logout</a>
</body>
</html>