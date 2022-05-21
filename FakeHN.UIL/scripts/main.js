// main page

function random(min, max) {
    return Math.floor(Math.random() * (max - min + 1) + min);
}

$(document).ready(function () {

    // TOP3 text truncate
    $('#carouselTOP3 .carousel-item .tile-body p').each(function () {

        let text = $(this).text();
        let window_width = $(window).width();

        // extra small screens
        if (window_width < 350) {
            $(this).text(text.slice(0, 150) + '...');
        }
        else if (350 <= window_width && window_width < 430) {
            $(this).text(text.slice(0, 180) + '...');
        }
        else if (430 <= window_width && window_width < 500) {
            $(this).text(text.slice(0, 200) + '...');
        }
        else if (500 <= window_width && window_width < 620) {
            $(this).text(text.slice(0, 250) + '...');
        }
        else if (500 <= window_width && window_width < 600) {
            $(this).text(text.slice(0, 275) + '...');
        }
        else if (600 <= window_width && window_width < 700) {
            $(this).text(text.slice(0, 300) + '...');
        }
        else if (700 <= window_width && window_width < 800) {
            $(this).text(text.slice(0, 325) + '...');
        }
        else {
            $(this).text(text);
        }

    });

    // TOP3 items footer color
    $('#carouselTOP3 #top3CarouselContent .carousel-item .carousel-caption').each(function (index, item) {
        if (index == 0) {
            item.style.color = 'green';
        }
        else if (index == 1) {
            item.style.color = 'red';
        }
        else {
            item.style.color = 'orange';
        }
    })

    $('.timeline-item').each(function () {

        // remove last child of comment section border
        let something = $(this).find('[id^=commentSection]');
        $(`#${something.attr('id')} .comment:last`).css('border', 'none')


        // coloring the items icons
        let colors = ['skublue', 'dodgerblue', 'tomato', 'yellow']
        let row = $(this).find('.row');
        let iconPart = row.find('.col-2');
        let icon = iconPart.find('.timeline-icon a');
        icon.css('background', colors[random(0, colors.length - 1)]);

    });

    // comment ajax
    $('[id^="commentButton"]').each(function () {
        $(this).click(function () {
            let postid = $(this).attr('id').substring(13);
            let comment = $(`[id^="commentInput${postid}"`).val().trim();
            $.ajax({
                type: 'POST',
                url: '../index.aspx/UpdateComments',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify({ postid: postid , comment: comment }),
                success: function (data) {
                    let commentSection = $(`[id^="allComments${postid}"`);
                    commentSection.append(data.d);
                }
            });
        });
    });


    // upvote ajax
    $('.upvote').each(function () {
        $(this).click(function () {

            let postid = $(this).attr('id').substring(9);
            let icon = $(this).find('#upvoteIcon');
            let txt = $(this).find('#upvoteText');
            let value = parseInt(txt.text());

            if ($(this).find('#upvoteIcon').attr('fill') === 'currentColor') {
                icon.attr('fill', 'orange');
                txt.css('color', 'orange');
                value += 1;
                txt.text(`${value}`)

                $.ajax({
                    type: 'POST',
                    url: '../index.aspx/UpdateVotes',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: JSON.stringify({ postid: postid, increase: true }),
                    success: function (data) {
                        alert('Voted !');
                    }
                });

            }
            else {
                icon.attr('fill', 'currentColor');
                txt.css('color', '');
                value -= 1;
                txt.text(`${value}`)

                $.ajax({
                    type: 'POST',
                    url: '../index.aspx/UpdateVotes',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: JSON.stringify({ postid: postid, increase: false }),
                    success: function (data) {
                        alert('Voted !');
                    }
                });
            }
        })
    });
});