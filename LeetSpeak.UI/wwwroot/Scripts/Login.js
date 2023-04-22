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
        ShowSuccessAlert("Login process has been completed");
    },
        function (response) { console.log(response) });
}

function OnLoginSuccess(response, data) {
    localStorage.setItem("token", response.token.accessToken);
    localStorage.setItem("ExpirationDate", JSON.stringify(response.token.expirationDate));
    InitiliazeLayout();
}

function OnLoginError() {
    console.log("xýrremeError");
}