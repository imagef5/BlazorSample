$(document).ready(function() {
  if ($('.gnb').length) {
    if ($('.gnb > li > ul').hasClass('gnb-dep2')) {
      $('.gnb > li > ul').parent().addClass('has-children');
    }
    gnb();
  }
  btnSearch();
  if ($('.banner-list').length) {
    bxSlideUi();
  }
  if ($('.category .tab-lst > li').length) {
    tabbasic();
  }

  if ($('.radiobox').length) {
    radiobox();
  }
  if ($('.selbox').length) {
    $('select').niceSelect();
  }
  if ($('.modalwrap').length) {
    ModalEvent();
  }
  if ($('.btn-time').length) {
    btnTime();
  }
  if ($('.accordion').length) {
  accordionEvt();
}


  $(document).mouseup(function(e) {
    var container = $('.header-inbox.open .nav-wrap');
    if (container.has(e.target).length === 0)
    $('.header-inbox').removeClass('open');
    $('body').css({
      overflow : 'inherit'
    }).unbind('touchmove');
  });

});

$(window).resize(function() {
  gnb();
});

function gnb() {
  var viewportwidth = $(window).width();
  if (viewportwidth > 1250) {
    gnbPc();

  } else {
    gnbMobile();
  }
}

function gnbPc() {
  $('.gnb > li > a').off('click');
  $('.gnb > li').removeClass('active');
  $('.gnb-dep2').css('display', 'block');
  $('.gnb').on('mouseover focusin', function() {
    $('header').addClass('on');
  });
  $('.gnb').on('mouseout focusout', function() {
    $('header').removeClass('on');
  });
  $('.gnb > li > a').on('mouseover focusin', function() {
    $('header').addClass('on');
    $('.gnb > li').removeClass('active');
    $(this).parent().addClass('active');
    return false;
  });
  $('.gnb > li > a').on('mouseout focusout', function() {
    $('.gnb > li').removeClass('active');
  });
  $('.gnb-dep2').on('mouseover focusin', function() {
    $(this).parent().addClass('active');
  });
  $('.gnb-dep2').on('mouseout focusout', function() {
    $(this).parent().removeClass('active');
  });
}

function gnbMobile() {
  $('.gnb > li > a').off('click');
  $('.gnb > li > a').off('mouseover');
  $('.gnb > li > a').off('focusin');
  $('.gnb > li > a').off('mouseout');
  $('.gnb > li > a').off('focusout');
  $('.gnb-dep2').off('mouseover');
  $('.gnb-dep2').off('focusin');
  $('.gnb-dep2').off('mouseout');
  $('.gnb-dep2').off('focusout');

  $('.gnb > li > a').click(function(e) {
    e.preventDefault();
  });
  $('.gnb-dep2').css('display', 'none');
  $('.gnb > li').removeClass('active');
  $('.header-inbox').removeClass('open');
  $('.gnb > li.has_children > a').attr('href', '#');

  $('.gnb > li > a').click(function() {
    var link = $(this);
    var closestUl = link.closest('ul');
    var parallelActiveLinks = closestUl.find('.active');
    var closestLI = link.closest('li');
    var linkStatus = closestLI.hasClass('active');
    var count = 0;

    closestUl.find('ul.gnb-dep2').slideUp(function() {
      if (++count == closestUl.find('ul.gnb-dep2').length)
      parallelActiveLinks.removeClass("active");
    });

    if (!linkStatus) {
      closestLI.children('ul.gnb-dep2').slideDown();
      closestLI.addClass('active');
    }
  });

  $('.mobile-menu-open').on('click', function() {
    $('.header-inbox').addClass('open');
    $('body').css({
      overflow : 'hidden'
    }).bind('touchmove', function(e) {
      e.preventDefault();
    });
    return false;

  });

  $('.mobile-menu-close').on('click', function() {
    $('.header-inbox').removeClass('open');
    $('body').css({
      overflow : 'inherit'
    }).unbind('touchmove');
    return false;
  });
}

function btnSearch() {
  $('.gnb-utilit-menu.search').on('click', function() {
    $('.searchbox-wrap').toggleClass('active');
    if ($('.searchbox-wrap').hasClass('active')) {
      $('.gnb-utilit-menu.search').attr('title','검색영역 닫기');
    } else {
      $('.gnb-utilit-menu.search').attr('title','검색영역 열기');
    }

  });
}

function btnTime() {
  $('.btn-time').on('click', function() {
    $(this).toggleClass('active');
    if (  $(this).hasClass('active')) {
      $(this).attr('title','선택됨');
    } else {
        $(this).attr('title','');
    }

  });
}

function tabbasic() {
  var tNum = $('.tab-lst').length;
  for (var i = 0; i < tNum; i++) {
    var ttnum = 'col' + $('.tab-lst').eq(i).find('li').length;
    $('.tab-lst').eq(i).addClass(ttnum);
  }
  $('.category .tab-lst > li > a').on('click', function() {
    $(this).parent().parent().find('li').removeClass('active');
    $(this).parent().parent().find('a').removeAttr('title');
    $(this).parent().addClass('active');
    $(this).attr('title', '선택됨');
    var o = $(this).parent().index();
    $(this).parent().parent().parent().find('.tab_content').removeClass('active');
    $(this).parent().parent().parent().find('.tab_content').eq(o).addClass('active');
    return false;
  });
}

function radiobox() {
  $('.radiobox input[type=radio]').on('focusin', function() {
    $(this).parent().addClass('focus');
  });
  $('.radiobox input[type=radio]').on('focusout', function() {
    $(this).parent().removeClass('focus');
  });

}

function bxSlideUi() {
  //메인배너
  var mVisualBnr = $('.banner-list').bxSlider({
    // mode: 'fade',
    touchEnabled : true,
    controls : true,
    pager : true,
    auto : true,
    autoControls : true,
    responsive : true,
    autoHover : true,
    onSliderLoad : function(currentIndex) {
      $('.banner-list .banner-list-item').find('a').attr('tabindex', -1);
      $('.banner-list .banner-list-item').not('.bx-clone').eq(currentIndex).find('a').attr('tabindex', 0);
    },
    onSlideBefore : function($slideElement, oldIndex, newIndex) {
      $('.banner-list .banner-list-item').find('a').attr('tabindex', -1);
      $('.banner-list .banner-list-item').not('.bx-clone').eq(newIndex).find('a').attr('tabindex', 0);
    }
  });
  //메인베너 컨트롤 버튼
  $('.bx-start').hide();
  $('.bx-start').on('click', function() {
    $(this).hide();
    $(this).parent('.bx-controls-auto-item').next().find('.bx-stop').show();
  });
  $('.bx-stop').on('click', function() {
    $(this).hide();
    $(this).parent('.bx-controls-auto-item').prev().find('.bx-start').show();
  });

}

// MODAL
function ModalEvent() {
  if ($('.modalwrap').length > 0) {
    var $modal_btn = $('.md-btn');

    $modal_btn.on('click', function(e) {
      var $this = $(this),
      $id = '#' + $this.attr('class').split(' ')[1],
      $close_bg = '.md-bg';

      openModal($id, $close_bg);
      e.preventDefault();
    });

    function openModal(id, bg) {
      $(id).fadeIn();
      $(bg).fadeIn();
      if ($(id).is(':visible')) {
        $(bg).on('click', function() {
          $(id).fadeOut();
          $(this).fadeOut();
        });
      }
      $('.md-clo').on('click', function(e) {
        e.preventDefault();
        //$(this).parent().parent().parent().fadeOut();
        var target = $(this).attr('href');
        $(target).fadeOut();
      });
    }
  }
}


function accordionEvt() {
  $('.accordion-body:eq(0)').slideDown();
	$('.accordion-link').on('click', function(e) {
		e.preventDefault();
		var dropDown = $(this).parent().parent().next().find('.accordion-body');
		$('.accordion-body').not(dropDown).slideUp();
		if ($(this).hasClass('active')) {
			$(this).removeClass('active');
      $(this).parent().parent().next().removeClass('active');
			$(this).attr('title', '답변 열기');
		} else {
      $(this).parent().parent().next().addClass('active');
			$('.accordion-link.active').removeClass('active');
			$(this).addClass('active');
			$(this).attr('title', '답변 닫기');
		}
		dropDown.stop(false, true).slideToggle();
	});
};
