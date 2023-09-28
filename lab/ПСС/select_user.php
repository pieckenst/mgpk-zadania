<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
<title>results</title>
</head>

<body>
<?php
$connt = mysqli_connect("localhost", "root", "root","users");

$first_name = trim($_REQUEST['first_name']);


$sql_select = "SELECT * FROM users WHERE topic='$first_name'";
$result = mysqli_query($connt,$sql_select);


while ($row = mysqli_fetch_array($result)) {
        $field1name = $row["keysp"];
        $field2name = $row["date"];
        $field3name = $row["topic"];
        
        

        echo '<table border="1" cellspacing="5" cellpadding="5" width="100%"><tr> 
                  <td>'.$field1name.'</td> 
                  <td>'.$field2name.'</td> 
                  <td>'.$field3name.'</td> 
                  
				  <td>'.$field8name.'</td>
              </tr></table>';
    }


?>
<a href="lab24.html">return to search</a><br/><br/>

</body>
</html>