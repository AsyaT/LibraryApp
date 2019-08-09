
    function replaceTable() {
        alert(1);
        
            //Send the AJAX call to the server
            $.ajax({
                //The URL to process the request
                'url': '/Home/BooksTable',
                //The type of request, also known as the "method" in HTML forms
                //Can be 'GET' or 'POST'
                'type': 'GET',
                //Any post-data/get-data parameters
                //This is optional
                
                //The response from the server
                'success': function (data) {
                    //You can use any jQuery/JavaScript here!!!
                    $('#books-table').html(data);
                }
            
        });
    }
