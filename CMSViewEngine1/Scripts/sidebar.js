﻿
function w3_open() {
  document.getElementById("main").style.marginLeft = "25%";
  document.getElementById("mySidebar").style.width = "25%";
  document.getElementById("mySidebar").style.display = "block";
  document.getElementById("openNav").style.display = 'none';
}
function w3_close() {
  document.getElementById("main").style.marginLeft = "0%";
  document.getElementById("mySidebar").style.display = "none";
  document.getElementById("openNav").style.display = "inline-block";
}


//$(document).ready(function () {
//    var trigger = $('.hamburger'),
//        overlay = $('.overlay'),
//       isClosed = false;

//    trigger.click(function () {
//        hamburger_cross();
//    });

//    function hamburger_cross() {

//        if (isClosed == true) {
//            overlay.hide();
//            trigger.removeClass('is-open');
//            trigger.addClass('is-closed');
//            isClosed = false;
//        } else {
//            overlay.show();
//            trigger.removeClass('is-closed');
//            trigger.addClass('is-open');
//            isClosed = true;
//        }
//    }

//    $('[data-toggle="offcanvas"]').click(function () {
//        $('#wrapper').toggleClass('toggled');
//    });
//});


