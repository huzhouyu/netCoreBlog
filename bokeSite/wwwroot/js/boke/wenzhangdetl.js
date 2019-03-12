var BokeWenzhangdetl = function (needUserName) {
    var userName = "";
    userName = needUserName;
    $("#headListForType>li").click(function () {
        $("#headListForType>li").removeClass("active");
        $(this).addClass("active");
    });
    var is_mobile = navigator.userAgent.toLowerCase().match(/(ipod|iphone|android|coolpad|mmp|smartphone|midp|wap|xoom|symbian|j2me|blackberry|wince)/i) != null;    //进行userAgent匹配
    if (is_mobile) {
        $("#firstContainer > div > div").removeClass('col-xs-offset-1').removeClass('col-xs-10').addClass('col-xs-12').css('padding-left', "20px");
        $("#preview1 ol").css("width", "100%").css("padding-left","0px");
        $("#preview1 ul").css("width", "100%").css("padding-left", "0px");
        $("#preview1 img").css("width", "100%").css("height", "100%");
        $("#preview1 ul").css("width", "100%");
        $("#preview1").css("padding", "10px").css("overflow-x","hidden");

    }

    var json = {
        ChoiceLeixing: function (leixing) {
            if (leixing != '') {
                var tmp = $("#headListForType>li");
                for (var i = 0; i < tmp.length; i++) {
                    if ($(tmp[i]).attr("leixing") == leixing) {
                        $(tmp[i]).trigger("click");
                        break;
                    }
                }
            } else {
                $("#headListForType>li").first().trigger("click");
            }
        }
    }
    return json;




}