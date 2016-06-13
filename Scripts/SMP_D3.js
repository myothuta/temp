
function getSMP() {
    $.ajax({
        url: '',
        dataType: 'json',
        type: 'POST',
        success: function (data) {
            console.log("data", data);
        },
        error: function () {
            alert("error");
        }
    });
}

    function search() {

    }