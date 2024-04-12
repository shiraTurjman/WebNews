
$(document).ready(function () {

    $('.topic').click(function () {
        var postId = $(this).data('post-id');
        var $topic = $(this);
        /*$(this).css("background-color", "silver")*/
        $topic.css("background-color", "silver");

        $.ajax({
            url: '/News/GetPostDetails',
            type: 'GET',
            data: { postId: postId },
            success: function (data) {
                
                console.log(data);
                var post = JSON.parse(data);
                /*alert(post.Title)*/
                
                $('.postTitle').text(post.Title);
                $('.postBody').html(post.Body);
                $('.postLink').attr('href', post.Link);
                $('.postDetails').show();
                $topic.css("background-color", "white");
            },
            error: function (err) {
                
                alert("err" + err.statusText);
            }
        });

    });
});