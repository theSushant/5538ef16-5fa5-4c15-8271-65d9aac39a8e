$(() => {
    $(document).on('click', '#submitBtn', function (e) {
        e.preventDefault();
        var input = $('#input-numbers').val();
        $.ajax({
            type: 'POST',
            url: '/Lis/Compute',
            data: { input: input },
            dataType: 'json',
            success: function (data) {
                $('#output-numbers').text(data.result);
            },
            error: function (xhr) {
                $('#output-numbers').text('Error: ' + xhr.responseText);
            }
        });
    });

    $(document).on('click', '#resetBtn', function (e) {
        e.preventDefault();
        $('#input-numbers').val('');
        $('#output-numbers').val('');
    });
});