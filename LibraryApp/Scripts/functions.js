
    function replaceTable() {
            $.ajax({
                'url': '/Home/BooksTable',
                'type': 'GET',
                'success': function (data) {
                    $('#books-table').html(data);
                }
            
        });
    }
