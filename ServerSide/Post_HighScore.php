<?php
	$file_name = './highscore.txt';
	$content = $_POST["_content"];

	file_put_contents($file_name, $content);
?>