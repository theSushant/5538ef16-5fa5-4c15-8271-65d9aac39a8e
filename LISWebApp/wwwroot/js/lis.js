$(() => {
    $(document).on('click', '#submitBtn', function (e) {
        e.preventDefault();
        var input = $('#input-numbers').val().trim();
        $.ajax({
            type: 'POST',
            url: '/Lis/Compute',
            data: { input: input },
            dataType: 'json',
            success: function (data) {
                $('#output-numbers').text(data.result);
                $('#code-status-id').text('SUCCESS').removeClass('fail').addClass('success');
            },
            error: function (xhr) {
                $('#code-status-id').text('FAIL').removeClass('success').addClass('fail');
                $('#output-numbers').text('Error: ' + xhr.responseText);
            }
        });
    });

    $(document).on('click', '#resetBtn', function (e) {
        e.preventDefault();
        $('#input-numbers').val('');
        $('#output-numbers').val('');
        $('#code-status-id').text('').removeClass('success fail');
           
    });
});