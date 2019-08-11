
    function replaceTable() {
            $.ajax({
                'url': '/Home/BooksTable',
                'type': 'GET',
                'success': function (data) {
                    $('#books-table').html(data);
                }
            
        });
    }

    $("a.btn-remove-author-details").click(function (event) {
        event.preventDefault();
        console.log($(this).context.outerHTML);

        $(this).parents('.author-details').remove();
    });

    //function removeAuthorDetails(event)
    //{
    //    //alert($(this).parent('.author-details'));
    //    //event.preventDefault();
    //    console.log($(this).context.outerHTML);
    //    console.log($(this).parents('.author-details').context.outerHTML);
    //    $(this).parents('.author-details').remove();
        
    //}