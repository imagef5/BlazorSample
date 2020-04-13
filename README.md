# MVVM 패턴을 이용한 Blazor web and WebWidow Sample

# 1. 구성
- Blazor.Corona.Domain
    - 코로나 관련 정보 Domain 
- Blazor.Corona.Repository, Blazor.Corona.Services
    - DB 접근및 Business logic 관리
- Blazor.Corona.Configuration
    - Repository, Services DI 관리
- Blazor.Corona.View
    - Blazor.Corona.Web (웹페이지) & Blazor.Corona.Native (WebWindow) 에서 사용될 공통 페이지 프로젝트
    - MVVM 패턴적용
- Blazor.Corona.Web
    - Blazor.Corona.View 공통 페이지를 Web 으로 노출
- Blazor.Corona.Native
    - Blazor.Corona.View 공통 페이지를 WebWindow 로 노출

# 2. WebWindow를 위한 환경 설정
- Windows : [Chronium-based Edge 설치 필요](https://www.microsoft.com/ko-kr/edge)
- Linux : [WebKit](https://webkit.org/)
- Mac : Safari
- [참조 : Exploring WebWindow examples for Blazor on desktop](https://gunnarpeipman.com/blazor-on-desktop-webwindow-experiment/)

# 3. 기타 참조
- [MVVM Support in Blazor](https://blog.jeremylikness.com/blog/2019-01-04_mvvm-support-in-blazor/)
- [Prism](https://prismlibrary.com/)
    - Prism 은 현재 Blazor 와 통합되어 있지 않음, Prism 기능중 일부만 사용([Event Aggregator](https://prismlibrary.com/docs/event-aggregator.html))
