$(document).ready(function () {
    $("#btnSubmit").click(function () {
        var guessNumber = $("#guessForm").val();
        var result = '';
        $.ajax({
            type: "POST",
            url: '/Home/GuessNumber',
            async: false,
            data: JSON.stringify({ guess: guessNumber }),
            contentType: "application/json",
            success: function (data) {
                result = data;
            }
        });


        $("#guessForm").val(result);

        if (result === "You guessed correct!") {
            if (confirm('Do you want to play again?')) {
                $.ajax({
                    type: "POST",
                    url: '/Home/InitiateNewGame',
                    async: false,
                    data: JSON.stringify({ guess: guessNumber }),
                    contentType: "application/json",
                    success: function (data) {
                        result = data;
                    }
                });
                $("#guessForm").val("");

            } else {
                window.location.href = "http://www.google.com";
            }
        }
    });
});