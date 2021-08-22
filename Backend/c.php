<?php
	// Create functions
	function createInsertQueryString($table, $set) {
		return "insert into `$table` set $set";
	}
?>