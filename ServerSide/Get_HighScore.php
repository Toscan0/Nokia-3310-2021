<?php
	header("Access-Control-Allow-Origin: *");
	$curHighscore = file_get_contents('./highscore.txt');
	echo $curHighscore;
?>