<?php
try{

	$source = 'mysql:host=tsuts.tskoli.is;dbname=gru_h9_gru';
	$user = 'GRU_H9';
	$password = 'mypassword';

	$pdo = new PDO($source, $user, $password);

	$pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

	$pdo->exec('SET NAMES "utf8"');

}
catch (PDOException $e){
	
	echo "tenging tókst ekki". $e->getMessage();
	
}
?>