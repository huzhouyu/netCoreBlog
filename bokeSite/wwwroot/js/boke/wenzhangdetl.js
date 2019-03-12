var BokeWenzhangdetl = function (needUserName) {
    var userName = "";
    userName = needUserName;
    $("#headListForType>li").click(function () {
        $("#headListForType>li").removeClass("active");
        $(this).addClass("active");
    });

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