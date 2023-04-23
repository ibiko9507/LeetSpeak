$("#loginButton").click(function (event) {
    var loginUserRequest = {
        UserName: $("#userName").val(),
        Password: $("#password").val(),
    };

    Login(loginUserRequest, GenerateUrl("user/login"));
});

function Login(data, url) {
    CallAjax("POST", url, JSON.stringify(data), function (response) {
        OnLoginSuccess(response, data);
    },
        function (response) { OnLoginError(response); });
}

async function OnLoginSuccess(response, data) {
    await localStorage.setItem("token", response.token.accessToken);
    await localStorage.setItem("ExpirationDate", JSON.stringify(response.token.expirationDate));
    InitiliazeLayout();
    await changeBody("/Translate/Translation");
    ShowSuccessAlert("Login process has been completed");
}

function OnLoginError(response) {
    ShowSuccessAlert("Login process has completed with and error\n" + "" + JSON.stringify(response));
}