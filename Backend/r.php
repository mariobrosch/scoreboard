<?php
	// Read functions

	function createGetQueryString($table, $key, $filter) {
		if ($filter) {
			if($filter[1] == 'ISNULL') {
				return "select * from `$table` WHERE `$filter[0]` IS NULL";
			}	
			return "select * from `$table` WHERE `$filter[0]`='$filter[1]'";
		}
		
		return "select * from `$table`".($key?" WHERE id=$key":'');
	}
?>