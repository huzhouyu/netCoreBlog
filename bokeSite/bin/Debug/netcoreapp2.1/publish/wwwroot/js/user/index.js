/// <reference path="../../lib/jquery/dist/jquery.min.js" />
/// <reference path="../../lib/bootstrap/dist/js/bootstrap.min.js" />
$(function () {
    //获取用户信息
    $.post('/user/info', null, function (data, stu) {
        if (data.issuf) {
            $('.dl-log-user').text(data.userinfo[0].nicheng);
            $($('.lp-title-port')[0]).text(data.userinfo[0].nicheng);
        }
    });
    ///退出登陆
    $('.dl-log-quit').click(function () {
        $.post('/user/quit', null, function (data, stu) {
            if (data.issuf) {
                window.location.href = data.backurl;
            }
            else {
                alert('退出登陆失败');
            }
        });

    });


});