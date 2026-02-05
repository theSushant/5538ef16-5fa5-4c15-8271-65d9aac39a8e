$(() => {
    $(document).on('click', '#submitBtn', function (e) {
        e.preventDefault();
        var input = $('#input-numbers').val().trim();
        var isValidInput = validateInput(input);
        if (isValidInput != '' || isValidInput.length > 0) {
            $('#input-message').text(isValidInput).addClass('text-danger');
            return;
        }
        $('#input-message').text('').removeClass('text-danger');
        GetResult(input);
    });

    $(document).on('click', '#resetBtn', function (e) {
        e.preventDefault();
        $('#input-numbers').val('');
        $('#output-numbers').val('');
        $('#code-status-id').text('').removeClass('success fail');
        $('#output-header').removeClass('bg-danger text-white').addClass('bg-warning bg-success');
        $('#input-message').text('').removeClass('text-danger');
    });
});

function GetResult(input) {
    $.ajax({
        type: 'POST',
        url: '/Lis/Compute',
        data: { input: input },
        dataType: 'json',
        success: function (data) {
            $('#output-numbers').text(data.result);
            $('#code-status-id').text('SUCCESS').removeClass('fail').addClass('success');
            $('#output-header').removeClass('bg-warning bg-danger').addClass('bg-success text-white');
        },
        error: function (xhr) {
            $('#code-status-id').text('FAIL').removeClass('success').addClass('fail');
            $('#output-numbers').text('Error: ' + xhr.responseText);
            $('#output-header').removeClass('bg-warning bg-success').addClass('bg-danger text-white');
        }
    });
}

function validateInput(input) {
    if (!input || input.trim() === '') {
        return 'Input is required.';
    }
    var regex = /^\d+( \d+)*$/;
    if (!regex.test(input)) {
        return 'Only numbers separated by spaces are allowed.';
    }
    return '';
}
