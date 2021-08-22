<?php
	// Delete functions

	function createDeleteQueryString($table, $key, $filter) {
		if ($filter) {
			if($filter[1] == 'ISNULL') {
				return "delete from `$table` WHERE `$filter[0]` IS NULL";
			}
			return "delete from `$table` WHERE `$filter[0]`='$filter[1]'";
		}
		
		return "delete from `$table`".($key?" WHERE id=$key":'');
	}
?>