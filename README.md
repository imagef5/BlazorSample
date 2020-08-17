# MVVM 패턴을 이용한 Blazor web & WebWindow Sample

# 1. 구성
- Blazor.Corona.Domain
    - 코로나 관련 정보 Domain 
- Blazor.Corona.Repository, Blazor.Corona.Services
    - DB 접근및 Business logic 관리
    - Entity Framework Core
- Blazor.Corona.Configuration
    - Repository, Services DI 관리
- Blazor.Corona.View
    - Blazor.Corona. Web (웹페이지) & Blazor.Corona.Native (WebWindow) 에서 사용될 공통 페이지 프로젝트
    - MVVM 패턴적용
- Blazor.Corona. Web
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
    - Prism 기능중 일부만 사용([Event Aggregator](https://prismlibrary.com/docs/event-aggregator.html))

# 4. 고려사항
- 페이지 상에서 Component (일종의 partial view)를 분리하여 ViewModel을 구성한후 DB를 비동기로 호출할 경우 DbContext 가 인스턴스 스레드로부터 안전하지 않기때문에 병렬 스레드 사용시 문제가 발생할 수 있음.
    - DbContext 생성시 AddDbContextPool 호출대신 AddDbContext 호출후 컨텍스트 범위를 <span style="color:#FF0000;">___ServiceLifetime.Transient___</span> 로 등록해야 정상적으로 동작.

    ```cs
    public void ConfigureServices(IServiceCollection services)
    {
        ...//생략
        services.AddDbContext<CoronaContext>(options =>
                options.UseSqlServer
                (
                    configuration.GetConnectionString("DefaultConnection")
                )
            , ServiceLifetime.Transient);

        ...//생략
    ```
    - 또는 비동기 호출시 별도의 dbcontext 를 생성하여 처리 or ViewModel 을 페이지 하나로 통합
    - _DbContextPool 을 사용해야 하는 경우라면 위 사항을 고려하여 ViewModel 및 비동기 호출 설계_
    - [참조 : DbContext 스레딩 문제 방지](https://docs.microsoft.com/ko-kr/ef/core/miscellaneous/configuring-dbcontext#avoiding-dbcontext-threading-issues)
    
