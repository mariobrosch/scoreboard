<?php
	// Update functions
	function createUpdateQueryString($table, $key, $set) {
		return "update `$table` set $set where id=$key";
	}
?>