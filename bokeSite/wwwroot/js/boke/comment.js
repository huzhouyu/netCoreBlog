/// <reference path="../../lib/jquery/dist/jquery.min.js" />

//import { get } from "http";

//import { parse } from "querystring";

//import { get } from "http";

//高度自适应
$(function () {
    $('.content').flexText();
});

// <!--textarea限制字数-->

function keyUP(t) {
    var len = $(t).val().length;
    if (len > 500) {
        $(t).val($(t).val().substring(0, 500));
    }
}

//<!--点击评论创建评论条-->

$('.commentAll').on('click', '.plBtn', function () {
    //获取输入内容
    var keepthis = this;
    var oSize = $(this).siblings('.flex-text-wrap').find('.comment-input').val();
    console.log("欢迎使用😘");
    var obj = {};
    obj.wenzhangid = GetUrlParam('id');
    obj.pinglunneirong = oSize;
    $.get('/comment/Addcomment', obj, function (data, stu) {
        if (data.issuf) {
            //动态创建评论模块
            oHtml = '<div class="comment-show-con clearfix"><div class="comment-show-con-img pull-left"><img src="' + data.userinfo.touxiangurl
                + '" alt=""></div> <div class="comment-show-con-list pull-left clearfix"><div class="pl-text clearfix"> <a href="/' + data.userinfo.username
                + '" pinglunid=' + data.wenzhangpinglun.id + ' huifurenid=' + data.userinfo.id + ' target="_blank" class="comment-size-name">' + data.userinfo.nicheng
                + ': </a> <span class="my-pl-con">&nbsp;<pre>' + oSize + '</pre></span> </div> <div class="date-dz"> <span class="date-dz-left pull-left comment-time">'
                + data.wenzhangpinglun.pinglunshijian
                + '</span> <div class="date-dz-right pull-right comment-pl-block"><a href="javascript:;" pinglunid=' + data.wenzhangpinglun.id
                + ' class="removeBlock">删除</a> <a href="javascript:;" class="date-dz-pl pl-hf hf-con-block pull-left">回复</a> <span class="pull-left date-dz-line">|</span> <a href="javascript:;" class="date-dz-z pull-left"><i class="date-dz-z-click-red"></i>赞 (<i class="z-num" pinglunid=' + data.wenzhangpinglun.id + '>'
                + data.wenzhangpinglun.dianzanshu + '</i>)</a> </div> </div><div class="hf-list-con"></div></div> </div>';
            if (oSize.replace(/(^\s*)|(\s*$)/g, "") != '') {
                $(keepthis).parents('.reviewArea').siblings('.comment-show').prepend(oHtml);
                $(keepthis).siblings('.flex-text-wrap').find('.comment-input').prop('value', '').siblings('pre').find('span').text('');
            }
        }
        else {
            alert(data.msg);
        };
    });
});

//<!--点击回复动态创建回复块-->

$('.comment-show').on('click', '.pl-hf', function () {
    //获取回复人的名字
    var fhName = $(this).parents('.date-dz-right').parents('.date-dz').siblings('.pl-text').find('.comment-size-name').html();
    var pinglunid = $(this).parents('.date-dz-right').parents('.date-dz').siblings('.pl-text').children('.comment-size-name').first().attr('pinglunid');
    var huifurenid = $(this).parents('.date-dz-right').parents('.date-dz').siblings('.pl-text').children('.comment-size-name').first().attr('huifurenid');
    var href = $(this).parents('.date-dz-right').parents('.date-dz').siblings('.pl-text').children('.comment-size-name').first().attr('href');
    //回复@
    var fhN = '回复@' + fhName;
    //var oInput = $(this).parents('.date-dz-right').parents('.date-dz').siblings('.hf-con');
    var fhHtml = '<div class="hf-con pull-left"> <textarea class="content comment-input hf-input" pinglunid=' + pinglunid + ' huifurenid=' + huifurenid + ' href="' + href + '" placeholder="" onkeyup="keyUP(this)"></textarea> <a href="javascript:;" class="hf-pl">评论</a></div>';
    //显示回复
    if ($(this).is('.hf-con-block')) {
        $(this).parents('.date-dz-right').parents('.date-dz').append(fhHtml);
        $(this).removeClass('hf-con-block');
        $('.content').flexText();
        $(this).parents('.date-dz-right').siblings('.hf-con').find('.pre').css('padding', '6px 15px');
        //console.log($(this).parents('.date-dz-right').siblings('.hf-con').find('.pre'))
        //input框自动聚焦
        $(this).parents('.date-dz-right').siblings('.hf-con').find('.hf-input').val('').focus().val(fhN);
    } else {
        $(this).addClass('hf-con-block');
        $(this).parents('.date-dz-right').siblings('.hf-con').remove();
    }
});

//<!--评论回复块创建-->

$('.comment-show').on('click', '.hf-pl', function () {
    var oThis = $(this);
    //获取输入内容
    pinglunid = $(this).siblings('.flex-text-wrap').find('.hf-input').attr('pinglunid');
    huifurenid = $(this).siblings('.flex-text-wrap').find('.hf-input').attr('huifurenid');
    href = $(this).siblings('.flex-text-wrap').find('.hf-input').attr('href');
    var oHfVal = $(this).siblings('.flex-text-wrap').find('.hf-input').val();
    console.log(oHfVal)
    var oHfName = $(this).parents('.hf-con').parents('.date-dz').siblings('.pl-text').find('.comment-size-name').html();
    var oAllVal = '回复@' + oHfName;
    if (oHfVal.replace(/^ +| +$/g, '') == '' || oHfVal == oAllVal) {

    } else {
        $.getJSON("/js/comment/pl.json", function (data) {
            var oAt = '';
            var oHf = '';
            var obj = {};
            $.each(data, function (n, v) {
                delete v.hfContent;
                delete v.atName;
                var arr;
                var ohfNameArr;
                if (oHfVal.indexOf("@") == -1) {
                    data['atName'] = '';
                    data['hfContent'] = oHfVal;
                } else {
                    arr = oHfVal.split(':');
                    ohfNameArr = arr[0].split('@');
                    data['hfContent'] = arr[1];
                    data['atName'] = ohfNameArr[1];
                }

                if (data.atName == '') {
                    oAt = data.hfContent;
                } else {
                    oAt = '回复<a class="atName" href="' + href + '" target="_blank"  >@' + data.atName + '</a> : ' + data.hfContent;
                }
                oHf = data.hfName;
            });
            obj.pinglunneirong = data.hfContent;
            //obj.pinglunrenid =;
            //obj.pinglunid =;
            obj.pinglunid = pinglunid;
            obj.huifurenid = huifurenid;
            $.get('/comment/Addcommentson', obj, function (data, stu) {
                if (data.issuf) {
                    var oHtml = '<div class="all-pl-con"><div class="pl-text hfpl-text clearfix"><a href="/' + data.userinfo.username
                        + '" pinglunid=' + pinglunid + ' huifurenid=' + data.userinfo.id + ' target="_blank" class="comment-size-name">' + data.userinfo.nicheng
                        + ': </a><span class="my-pl-con">' + oAt + '</span></div><div class="date-dz"> <span class="date-dz-left pull-left comment-time">'
                        + data.wenzhangpinglunson.pinglunshijian + '</span> <div class="date-dz-right pull-right comment-pl-block"> <a href="javascript:;" pinglunsonid='
                        + data.wenzhangpinglunson.id + '  class="removeBlock">删除</a> <a href="javascript:;" class="date-dz-pl pl-hf hf-con-block pull-left">回复</a> <span class="pull-left date-dz-line">|</span> <a href="javascript:;" class="date-dz-z pull-left"><i class="date-dz-z-click-red"></i>赞 (<i class="z-num" pinglunsonid='
                        + data.wenzhangpinglunson.id + '>'
                        + data.wenzhangpinglunson.dianzanshu + '</i>)</a> </div> </div></div>';
                    oThis.parents('.hf-con').parents('.comment-show-con-list').find('.hf-list-con').css('display', 'block').append(oHtml) && oThis.parents('.hf-con').siblings('.date-dz-right').find('.pl-hf').addClass('hf-con-block') && oThis.parents('.hf-con').remove();
                }
                else {
                    alert(data.msg);
                }
            });
        });
    }
});

//<!--删除评论块-->

$('.commentAll').on('click', '.removeBlock', function () {
    var oT = $(this).parents('.date-dz-right').parents('.date-dz').parents('.all-pl-con');
    if (oT.siblings('.all-pl-con').length >= 1) {
        oT.remove();
    } else {
        $(this).parents('.date-dz-right').parents('.date-dz').parents('.all-pl-con').parents('.hf-list-con').css('display', 'none')
        oT.remove();
    }
    $(this).parents('.date-dz-right').parents('.date-dz').parents('.comment-show-con-list').parents('.comment-show-con').remove();
    var del = $(this);
    if (del.attr('pinglunsonid') != undefined) {
        var obj = {};
        obj.id = del.attr('pinglunsonid');
        $.get('/comment/delcommentson', obj, function (data, stu) {
            if (!data.issuf) {
                alert('删除失败！！！');
            }
        });
    }
    else {
        var obj = {};
        obj.id = del.attr('pinglunid');
        $.get('/comment/delcomment', obj, function (data, stu) {
            if (!data.issuf) {
                alert('删除失败！！！！');
            }
        });
    }
})

//<!--点赞-->
$('.comment-show').on('click', '.date-dz-z', function () {
    var zNum = $(this).find('.z-num').html();
    var del = $(this).find('.z-num');
    if ($(this).is('.date-dz-z-click')) {
        //zNum--;
        //$(this).removeClass('date-dz-z-click red');
        //$(this).find('.z-num').html(zNum);
        //$(this).find('.date-dz-z-click-red').removeClass('red');
        //if (del.attr('pinglunsonid') != undefined) {
        //    var obj = {};
        //    obj.id = del.attr('pinglunsonid');
        //    $.get('/comment/delcommentson', obj, function (data, stu) {
        //        if (!data.issuf) {
        //            alert('删除失败！！！');
        //        }
        //    });
        //}
        //else {
        //    var obj = {};
        //    obj.id = del.attr('pinglunid');
        //    $.get('/comment/delcomment', obj, function (data, stu) {
        //        if (!data.issuf) {
        //            alert('删除失败！！！！');
        //        }
        //    });
        //}

    } else {
        zNum++;
        $(this).addClass('date-dz-z-click');
        $(this).find('.z-num').html(zNum);
        $(this).find('.date-dz-z-click-red').addClass('red');

        if (del.attr('pinglunsonid') != undefined) {
            var obj = {};
            obj.id = del.attr('pinglunsonid');
            obj.dianzanshu = zNum;
            $.get('/comment/pinglundianzhanson', obj, function (data, stu) {
            });
        }
        else {
            var obj = {};
            obj.id = del.attr('pinglunid');
            obj.dianzanshu = zNum;
            $.get('/comment/pinglundianzhan', obj, function (data, stu) {
            });
        }
    }
})
///获取评论
function getpinglun(id, page, pagecount) {
    var obj = {};
    obj.id = id;
    obj.page = page;
    obj.pagecount = pagecount;
    $.post('/comment/commentlist', obj, function (data, stu) {

        if (data.issuf) {
            if (data.content != undefined && data.content.length > 0) {
                $.each(data.content, function (key, val) {
                    var pinlunhtml = '<div class="comment-show-con clearfix"><div class="comment-show-con-img pull-left" > <img src="' + val.usertouxiangurl + '" alt=""></div><div class="comment-show-con-list pull-left clearfix"><div class="pl-text clearfix"><a href="/' + val.pinglunrenusername + '" pinglunid=' + val.id + ' huifurenid=' + val.pinglunrenid + ' target="_blank" class="comment-size-name">' + val.pinglunrennicheng + ': </a> <span class="my-pl-con">&nbsp;<pre>' + val.pinglunneirong + '</pre></span> </div><div class="date-dz"> <span class="date-dz-left pull-left comment-time">' + val.pinglunshijian + '</span><div class="date-dz-right pull-right comment-pl-block"><a href="javascript:;" pinglunid=' + val.id + ' class="removeBlock">删除</a><a href="javascript:;" class="date-dz-pl pl-hf pull-left hf-con-block">回复</a> <span class="pull-left date-dz-line">|</span><a href="javascript:;" class="date-dz-z pull-left"><i class="date-dz-z-click-red"></i>赞 (<i class="z-num" pinglunid=' + val.id + '>' + val.dianzanshu + '</i>)</a></div></div><div class="hf-list-con" style="display: block;">';
                    if (val.wenzhangpinglunsonlist.content != undefined && val.wenzhangpinglunsonlist.content.length > 0) {
                        $.each(val.wenzhangpinglunsonlist.content, function (key, val1) {

                            pinlunhtml += '<div class="all-pl-con"><div class="pl-text hfpl-text clearfix" ><a href="/' + val1.pinglunrenusername + '" pinglunid=' + val1.pinglunid + ' huifurenid=' + val1.huifurenid + ' target="_blank" class="comment-size-name">' + val1.pinglunrennicheng + ': </a> <span class="my-pl-con">回复<a class="atName" href="/' + val1.pinglunrenusername + '" target="_blank">@' + val1.huifurennicheng + '</a> :  ' + val1.pinglunneirong + '</span></div ><div class="date-dz"> <span class="date-dz-left pull-left comment-time">' + val1.pinglunshijian + '</span><div class="date-dz-right pull-right comment-pl-block"><a href="javascript:;" pinglunsonid=' + val1.id + ' class="removeBlock">删除</a><a href="javascript:;" class="date-dz-pl pl-hf pull-left hf-con-block">回复</a> <span class="pull-left date-dz-line">|</span><a href="javascript:;" class="date-dz-z pull-left"><i class="date-dz-z-click-red"></i>赞 (<i class="z-num" pinglunsonid=' + val1.id + '>' + val1.dianzanshu + '</i>)</a></div></div></div >';
                        });
                        if (val.wenzhangpinglunsonlist.count > val.wenzhangpinglunsonlist.msg) {
                            pinlunhtml += '<div class="all-pl-con text-center"><button type="button" class="btn btn-danger jiazaipinglunson" pinglunid=' + val.id + ' start=' + parseInt(val.wenzhangpinglunsonlist.msg) + '>再看几条</button></div >';
                        }
                    }
                    pinlunhtml += '</div></div></div >';
                    $('.comment-show').append(pinlunhtml);
                });
                if (data.count > data.msg) {
                    var foot = '<div class="comment-show-con clearfix text-center"><button type="button" class="btn btn-danger jiazaipinglun" wenzhangid=' + id + ' start=' + data.msg + '>再看几条</button></div >';
                    $('.comment-show').append(foot);
                    if ($('.jiazaipinglun').length > 1) {
                        $('.jiazaipinglun').first().parent().remove();
                    }
                }
                else {
                    $('.jiazaipinglun').parent().remove();
                    window.clearInterval(tmer);
                }

            }

            ///加载评论
            $('.jiazaipinglun').click(function () {
                var obj = {};
                obj.id = $(this).attr('wenzhangid');
                obj.page = $(this).attr('start') / 20;
                obj.pagecount = 20;
                getpinglun(obj.id, obj.page, obj.pagecount);
            });
            ///加载子评论
            $('.jiazaipinglunson').click(function () {
                var obj = {};
                obj.id = $(this).attr('pinglunid');
                obj.page = $(this).attr('start') / 5;
                obj.pagecount = 5;
                var thisduixiang = $(this);
                $.get('/comment/commentsonlist', obj, function (data, stu) {
                    var val = data.result;
                    if (val.issuf) {
                        $.each(val.content, function (key, val1) {

                            pinlunhtml = '<div class="all-pl-con"><div class="pl-text hfpl-text clearfix" ><a href="/' + val1.pinglunrenusername + '" pinglunid=' + val1.pinglunid + ' huifurenid=' + val1.huifurenid + ' target="_blank" class="comment-size-name">' + val1.pinglunrennicheng + ': </a> <span class="my-pl-con">回复<a class="atName" href="/' + val1.pinglunrenusername + '" target="_blank">@' + val1.huifurennicheng + '</a> :  ' + val1.pinglunneirong + '</span></div ><div class="date-dz"> <span class="date-dz-left pull-left comment-time">' + val1.pinglunshijian + '</span><div class="date-dz-right pull-right comment-pl-block"><a href="javascript:;" pinglunsonid=' + val1.id + ' class="removeBlock">删除</a><a href="javascript:;" class="date-dz-pl pl-hf pull-left hf-con-block">回复</a> <span class="pull-left date-dz-line">|</span><a href="javascript:;" class="date-dz-z pull-left"><i class="date-dz-z-click-red"></i>赞 (<i class="z-num" pinglunsonid=' + val1.id + '>' + val1.dianzanshu + '</i>)</a></div></div></div >';
                            thisduixiang.parent().before(pinlunhtml);
                        });
                        if (val.count > val.msg) {
                            thisduixiang.attr('start', val.wenzhangpinglunsonlist.msg + 1);
                        }
                        else {
                            thisduixiang.parent().remove();
                        }

                    }

                });
            });
        }



    });

}
$(function () {
    getpinglun(GetUrlParam('id'), 0, 20);
})






//文档高度
function getDocumentTop() {

    var scrollTop = 0, bodyScrollTop = 0, documentScrollTop = 0;

    if (document.body) {
        bodyScrollTop = document.body.scrollTop;
    }
    if (document.documentElement) {
        documentScrollTop = document.documentElement.scrollTop;
    }

    scrollTop = (bodyScrollTop - documentScrollTop > 0) ? bodyScrollTop : documentScrollTop; return scrollTop;

}

//可视窗口高度

function getWindowHeight() {

    var windowHeight = 0;
    if (document.compatMode == "CSS1Compat") {

        windowHeight = document.documentElement.clientHeight;

    } else {

        windowHeight = document.body.clientHeight;

    }

    return windowHeight;

}



//滚动条滚动高度

function getScrollHeight() {

    var scrollHeight = 0, bodyScrollHeight = 0, documentScrollHeight = 0;

    if (document.body) {

        bodyScrollHeight = document.body.scrollHeight;

    }

    if (document.documentElement) {

        documentScrollHeight = document.documentElement.scrollHeight;

    }

    scrollHeight = (bodyScrollHeight - documentScrollHeight > 0) ? bodyScrollHeight : documentScrollHeight;
    return scrollHeight;

}

var tmer = setInterval(jiazaipinglun, 2000);



window.onscroll = function () {
    //监听事件内容
    //alert('到底部了');
    if (getScrollHeight() < getWindowHeight() + getDocumentTop() + 100) {
        //当滚动条到底时,这里是触发内容
        //异步请求数据,局部刷新dom
        //alert('到底部了');
    }
}




function jiazaipinglun() {
    if (getScrollHeight() < getWindowHeight() + getDocumentTop() + 700) {
        //当滚动条到底时,这里是触发内容
        //异步请求数据,局部刷新dom
        $('.jiazaipinglun').trigger('click');
    }
}


///获取指定参数
function GetUrlParam(paraName) {
    var url = document.location.toString();
    if (paraName == 'id') {
        var tmp = url.split('/');
        return tmp[tmp.length - 1];
    }
    var arrObj = url.split("?");

    if (arrObj.length > 1) {
        var arrPara = arrObj[1].split("&");
        var arr;

        for (var i = 0; i < arrPara.length; i++) {
            arr = arrPara[i].split("=");

            if (arr != null && arr[0] == paraName) {
                return arr[1];
            }
        }
        return "";
    }
    else {
        return "";
    }
}
