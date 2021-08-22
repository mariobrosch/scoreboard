<?php
	// Helper functions

	function getUrlParts() {
		return explode('/', trim($_SERVER['PATH_INFO'],'/'));
	}

	function getTable() {
		return preg_replace('/[^a-z0-9_]+/i','',getUrlParts()[0]);
	}

	function getId() {
		$id = getUrlParts()[1];
		return $id+0;
	}

	function getFilter() {
	    // filter should be in url like: ?filter[column]=value
		// for example: ?filter[name]=john
		$filterPart = $_SERVER['QUERY_STRING'];
		if ($filterPart) {
			$keyValue = explode('=', $filterPart);	
			$filterColumn = $keyValue[0];
			$filterColumn = str_ireplace(']','',str_ireplace('filter[','', $filterColumn));
			$filterValue = $keyValue[1];
			$returnValue = [$filterColumn,$filterValue];
			return $returnValue;
		}
		return false;
	}

	function getSetValues() {
		$input = json_decode(file_get_contents('php://input'),true);
		// escape the columns and values from the input object
		$columns = preg_replace('/[^a-z0-9_]+/i','',array_keys($input));
		$values = array_map(function ($value) use ($link) {
			if ($value===null) {
				return null;
			}

			return (string)$value;
		},array_values($input));
 
		// build the SET part of the SQL command
		$set = '';
		for ($i=0;$i<count($columns);$i++) {
			$set.=($i>0?',':'').'`'.$columns[$i].'`=';
			$set.=($values[$i]===null?'NULL':'"'.$values[$i].'"');
		}

		return $set;
	}
?>