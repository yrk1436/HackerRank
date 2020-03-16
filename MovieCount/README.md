# Countng Movies
## Instructions

Write an HTTP GET method to retrieve information from a movie database concerning how many movies have a particular string in their title. Given a search term query *https:////jsonmock.hackerrank.com//api//movies//search//?Title=[substr]*. The query response will be a JSON object with the following fields:

- *page*: The current page.
- *per_page*: The maximum number of results per page.
- *total*: The total number of movies having the substring *substr* in their title.
- *total_pages*: The total number of pages which must be queried to get all the results.
- *data*: An array of JSON objects containing movie information where the *Title* field denotes the title of the movie.

**Function Description**
Complete the function *getNumberOfMovies*

**Example**
if argument *maze* is passed, the database have 97 titles having the word.