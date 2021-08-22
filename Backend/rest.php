<?php
 
include 'h.php';
include 'c.php';
include 'd.php';
include 'f.php';
include 'r.php';
include 'u.php';

// get the HTTP method, path and body of the request
$method = $_SERVER['REQUEST_METHOD'];
$urlParts = getUrlParts();
 
// connect to the mysql database
$link = mysqli_connect('localhost', '', '', '');
mysqli_set_charset($link,'utf8');
 
// create SQL based on HTTP method
switch ($method) {
  case 'GET':
    $sql = createGetQueryString(getTable(), getId(), getFilter()); 
    break;
  case 'PUT':
    $sql = createUpdateQueryString(getTable(), getId(), getSetValues()); 
    break;
  case 'POST':
    $sql = createInsertQueryString(getTable(), getSetValues()); 
    break;
  case 'DELETE':
    $sql = createDeleteQueryString(getTable(), getId(), getFilter()); 
    break;
}
 
// excecute SQL statement
$result = mysqli_query($link, $sql);
 
// die if SQL statement failed
if (!$result) {
    http_response_code(405);
    die(mysqli_error($link));
}

header('Content-Type: application/json');
 
// print results, insert id or affected row count
if ($method == 'GET') {
    echo '[';
    for ($i=0;$i<mysqli_num_rows($result);$i++) {
        echo ($i>0?',':'').json_encode(mysqli_fetch_object($result));
    }
    echo ']';
}
elseif ($method == 'POST') {
    echo mysqli_insert_id($link);
}
else {
    echo mysqli_affected_rows($link);
} 

// close mysql connection
mysqli_close($link);

?>