<?php
require_once 'lib/twitteroauth.php';

$tField1 = $_GET['term'];
$tField2 = $_GET['geocode'];
 
define('CONSUMER_KEY', 'LQ9n9fhM4TGUWLPyx25x5CmV8');
define('CONSUMER_SECRET', 'xxMoLbe4j2qP1N5LQU6w6uvUqmwoNjG5tbElCCHAFQXEWcHs8G');
define('ACCESS_TOKEN', '783502369392762880-SsMXmqgzYha0I4tdNXcKdQzYNN9qYOS');
define('ACCESS_TOKEN_SECRET', '2a36fDal4rjZ3EMdbXZZ1QSeFuok4XHmi5unIqGbZ4uSp');
 
function search(array $query)
{
  $toa = new TwitterOAuth(CONSUMER_KEY, CONSUMER_SECRET, ACCESS_TOKEN, ACCESS_TOKEN_SECRET);
  return $toa->get('search/tweets', $query);
}
 
$query = array(
  "q" => $tField1,
  "lang" => "en",
  "geocode" => $tField2,
  “exclude” => “retweets”
);

$results = search($query);
 
foreach ($results->statuses as $result) {
  echo $result->user->profile_image_url . " :? " . $result->user->screen_name . " :? " . $result->text . " :? ";
}

