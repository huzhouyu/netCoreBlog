/// <reference path="../../lib/jquery/dist/jquery.js" />


var BokeIndex = function (needUserName) {

    var userName = "";
    userName = needUserName;
    $("#headListForType>li").click(function () {
        $("#headListForType>li").removeClass("active");
        $(this).addClass("active");
        $.get($(this).children("a").attr("needhref"), { username: userName }, function (data, stu) {
            $("#wenzhanglistUl").empty();
            if (data.issuf) {
                var htmlstr = "";
                if (data.count > 0) {
                    var wenzhangleixinglist = data.content;
                    if (wenzhangleixinglist[0].toal == 0) {
                        htmlstr = '<li>没有发现文章</li >';
                        $("#wenzhanglistUl").append(htmlstr);
                        return;
                    }
                    for (var i = 0; i < data.count; i++) {
                        var row = wenzhangleixinglist[i];
                        htmlstr += '<li href="/' + userName + '/wenzhang/' + row.id + '"><h3 > <a class="cat" href="#" title="' + row.leixingming + '">' + row.leixingming + '<i></i></a>' + row.wenzhangname + '</h3 ><p class="meta"><time class="time"><i class="glyphicon glyphicon-time"></i>' + row.xiugaishijian + '  </time><span class="views"><i class="glyphicon glyphicon-eye-open"></i>' + row.dianjiliang + '  </span> <a class="comment chakanxiangqing" wenzhangtitle="wenzhangname" href="#" title="评论"><i class="glyphicon glyphicon-comment"></i>' + row.pingluntiaoshu + '  </a></p><p>' + row.content100 + '</p></li >';
                    }
                    $("#wenzhanglistUl").append(htmlstr);
                }
                else {

                }
            };
            $("#wenzhanglistUl>li").click(function () {
                window.location.href = $(this).attr("href");
            });
        });
    });
    var is_mobile = navigator.userAgent.toLowerCase().match(/(ipod|iphone|android|coolpad|mmp|smartphone|midp|wap|xoom|symbian|j2me|blackberry|wince)/i) != null;    //进行userAgent匹配
    if (is_mobile) {
        $("#firstContainer > div > div").removeClass('col-xs-offset-1').removeClass('col-xs-10').addClass('col-xs-12').css('padding-left', "20px");
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