USE [corona]
GO
/****** Object:  Table [dbo].[board_195]    Script Date: 2020-03-05 오후 5:46:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[board_195](
	[seq] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](200) NULL,
	[content] [varchar](max) NULL,
	[created] [datetime] NULL,
	[readnum] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[seq] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[board_196]    Script Date: 2020-03-05 오후 5:46:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[board_196](
	[seq] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](200) NULL,
	[content] [varchar](max) NULL,
	[created] [datetime] NULL,
	[readnum] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[seq] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Coronavirus_incheon]    Script Date: 2020-03-05 오후 5:46:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coronavirus_local](
	[idx] [int] IDENTITY(1,1) NOT NULL,
	[whole_confirmed_cnt] [int] NULL,
	[death_cnt] [int] NULL,
	[checkup_cnt] [int] NULL,
	[negative_cnt] [int] NULL,
	[local_confirmed_cnt] [int] NULL,
	[confirmd_increase_cnt] [int] NULL,
	[local_contacted_cnt] [int] NULL,
	[contacted_increase_cnt] [int] NULL,
	[local_similar_cnt] [int] NULL,
	[similar_increase_cnt] [int] NULL,
	[local_self_isolation_cnt] [int] NULL,
	[self_isolation_increase_cnt] [int] NULL,
	[from_wuhan_cnt] [int] NULL,
	[wuhan_increase_cnt] [int] NULL,
	[offered] [datetime] NULL,
	[created] [datetime] NULL,
	[modified] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Coronavirus_info]    Script Date: 2020-03-05 오후 5:46:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coronavirus_info](
	[idx] [int] IDENTITY(1,1) NOT NULL,
	[contacted_self_isolation] [int] NULL,
	[clear_contacted_self_isolation] [int] NULL,
	[isolation_cnt] [int] NULL,
	[clear_isolation_cnt] [int] NULL,
	[self_isolation] [int] NULL,
	[clear_self_isolation] [int] NULL,
	[created] [datetime] NULL,
	[modified] [datetime] NULL,
	[offered] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[board_195] ADD  DEFAULT (getdate()) FOR [created]
GO
ALTER TABLE [dbo].[board_195] ADD  DEFAULT ((0)) FOR [readnum]
GO
ALTER TABLE [dbo].[board_196] ADD  DEFAULT (getdate()) FOR [created]
GO
ALTER TABLE [dbo].[board_196] ADD  DEFAULT ((0)) FOR [readnum]
GO
ALTER TABLE [dbo].[Coronavirus_local] ADD  DEFAULT (getdate()) FOR [created]
GO
ALTER TABLE [dbo].[Coronavirus_local] ADD  DEFAULT (getdate()) FOR [modified]
GO
ALTER TABLE [dbo].[Coronavirus_info] ADD  DEFAULT (getdate()) FOR [created]
GO
ALTER TABLE [dbo].[Coronavirus_info] ADD  DEFAULT (getdate()) FOR [modified]
GO

/* Sample Data */
INSERT board_195(title, content) VALUES (N'신종 코로나바이러스 감염증 관련 용어(2020. 2. 7. 기준)',N'<p>2020.02.07.자 대응지침 5판<br>  □ ''의사환자'' 기준을&nbsp;기존 ''후베이성'' &rarr; ''중국''으로 확대<br>□&nbsp;''의사환자'' 기준에&nbsp;"의사의 소견에 따라 코로나바이러스감염증 의심되는 자" 항목 추가</p>  <p><br></p>  <p><br></p>  <p>1. 환자 분류</p>  <p>의사환자(Suspected case)<span style="white-space: pre;"></span></p>  <p>○ 중국을 다녀온 후 14일 이내에 발열(37.5℃ 이상) 또는 호흡기증상(기침, 인후통 등)이 나타난 사람</p>  <p>○ 확진환자의 증상발생 기간 중 확진환자와 밀접하게 접촉한 후 14일 이내에 발열(37.5℃ 이상)&nbsp; 또는 호흡기증상(기침, 인후통 등)이 나타난 사람</p>  <p>○ 의사의 소견에 따라 신종 코로나바이러스감염증이 의심되는 사람(유행국가 여행력 고려 등)&nbsp;&nbsp;</p>  <p>※ 역학조사관이 결정&nbsp;&nbsp;</p>  <p>&gt; 국가지정입원치료병상(음압병실) 입원 / 경증일 경우 자가격리 가능</p>  <p><br></p>  <p>조사대상 유증상자(Patient Under Investigation)<span style="white-space: pre;"></span></p>  <p>○ 중국을 방문한 후 14일 이내에 폐렴(영상의학적으로 확인된 폐렴)이 나타난 사람&nbsp; &nbsp;&nbsp;</p>  <p>※ 역학조사관이 조사대상 유증상자 여부 결정</p>  <p>&gt; 국가지정입원치료병상(음압병실) 입원&nbsp; / 경증일&nbsp; 경우 자가격리 가능</p>  <p><br></p>  <p>확진환자(Confirmed case)<span style="white-space: pre;"></span></p>  <p>○ 의사환자 중 진단검사 기준에 따라 감염병 병원체 감염이 확인된 사람&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</p>  <p>※ 실험실 검사결과로 최종 결정&nbsp; &nbsp;&nbsp;</p>  <p>&gt; 국가지정입원치료병상(음압병실) 입원</p>  <p>&nbsp; </p>  <div><br></div>  <div>2. 자가격리대상자<br>  ○ 능동감시대상자 + 자가격리 = 자가격리대상자<br>  ○ 확진자 접촉여부가 불확실하나 역학조사관이 종합 판단하여 결정<br>  ○ 의사환자 또는 조사대상 유증상자가 아니면서 중국 방문 후 14일 이내 발열과 호흡기 증상이 있는 경우로서 역학조사관이 종합 판단하여 결정(영상의학적 확인과정 가능)<br>  &gt; &nbsp;능동감시(관할보건소에서 매일 2회 전화 확인) 및 자가격리<br>  <br>  3. 접촉자 (기존 일상접촉자와 밀접접촉자 구분 폐지)<br>  ○ 확진환자의 증상이&nbsp;나타나기 시작한&nbsp;이후&nbsp;2미터 이내 접촉이 이루어진 사람,&nbsp;확진환자가 폐쇄공간에서 마스크를 쓰지 않고 기침을 할 때 같은 공간에 있었던 사람 등 역학조사관 판단에 따름<br>  <br>  4. 관리형태 분류<br>  ○ 능동감시 : 관할 보건소에서 매일 2회 전화 연락하여 발열과 호흡기 증상 여부 확인 (보통 14일 동안)<br>○ 자가격리 : 지역사회 전파를 차단하기 위해, 즉시 대응 및 관리 목적으로 적용되는 자율 격리 방식(역학조사관 판단으로 기간은 다를 수 있음)</div>')
GO
INSERT board_196(title, content) VALUES (N'코로나 대응 관련 홍보자료(예방수칙 등)',N'<div><img src="/corona/images/corona_01.jpg" style="width: 100%;" alt=""></div>  <div><img src="/corona/images/corona_02.jpg" style="width: 100%;" alt=""></div>  <div><img src="/corona/images/corona_03.png" style="width: 100%;" alt=""></div>')
GO
INSERT board_196(title, content) VALUES (N'알려드립니다(1보)',N'<p><span style="FONT-SIZE: 12pt">&lt;2020.2.10. (월) 18시 현재&gt;</span><br>  <span style="FONT-SIZE: 12pt">안녕하십니까. 골목골목 행복을 만들기 위해 노력하고 있는 OOO구입니다.</span><br>  <span style="FONT-SIZE: 12pt">중국 우한시에서 시작된 신종 코로나바이러스 감염증이 전세계를 뒤흔들고 있습니다.</span><br>  <span style="FONT-SIZE: 12pt">현재 정부 각 부처는 물론 모든 지방정부와 관계기관들이 신종 코로나 확산방지에 총력을 기울이고 있습니다.</span></p>  <p><span style="FONT-SIZE: 12pt"></span>&nbsp;</p>  <p><span style="FONT-SIZE: 12pt">OOO구는 OOO시와 함께 신종 코로나와 관련한 모든 정보를 투명하고 신속하게 공개하기 위해 &lsquo;신종 코로나바이러스 감염증 관련 OOO구 알리미 사이트&rsquo;를 만들었습니다.</span></p>  <p><span style="FONT-SIZE: 12pt"></span>&nbsp;</p>  <p><span style="FONT-SIZE: 12pt">앞으로 이 공간에서 OOO 주민들이 궁금해 하실 신종 코로나와 관련한 모든 정보를 공개하고 알려드리겠습니다.</span></p>  <p><span style="FONT-SIZE: 12pt"></span><br>  <span style="FONT-SIZE: 12pt">OOO구가 마련한 신종 코로나 알리미 사이트 첫 번째 소식으로 OOO구는 신종 코로나 확진환자가 아직까지 한 명도 발생하지 않았다는 내용부터 전합니다.</span></p>  <p><span style="FONT-SIZE: 12pt">OOO시는 2월 10일 18시 기준으로 확진자는 없고, 확진자 접촉자 38명, 의사환자 16명, 자가격리 대상자 58명입니다.</span></p>  <p><span style="FONT-SIZE: 12pt"></span>&nbsp;</p>  <p><span style="FONT-SIZE: 12pt">OOO구는 전염병 확산 방지를 위해선 &lsquo;과도한 선제적 대응&rsquo;이 중요하다는 판단아래 1월 29일부터 재난안전대책본부와 함께 관련부서 24시간 풀가동 체제로 상황 대응에 나서고 있습니다.</span></p>  <p><span style="FONT-SIZE: 12pt"></span>&nbsp;</p>  <p><span style="FONT-SIZE: 12pt">재난관리기금 1억원을 긴급 편성하고 특별조정교부금 1억1천7백만원으로&nbsp;마스크, 손소독제, 열감지기를 구입해 기존 열감지기와 함께 28개소에 설치를 마칠 계획입니다.</span></p><span style="FONT-SIZE: 12pt"></span>  <p><br>  <span style="FONT-SIZE: 12pt">OOO구보건소와 OOO사랑병원, 현재유비스병원은 선별진료소를 운영하며 환자상담과 증상을 체크하고 있습니다.</span></p>  <p><span style="FONT-SIZE: 12pt"></span>&nbsp;</p>  <p><span style="FONT-SIZE: 12pt">방역에도 만전을 기하고 있습니다.</span><br>  <span style="FONT-SIZE: 12pt">지난 4일부터 OOO구 21개동 별로 방역소독을 실시하고 있고 전철역사와 OOO터미널, 공원, 경로당, 도서관, 전통시장, 복지시설에도 방역소독을 실시하고 있습니다.</span></p>  <p><span style="FONT-SIZE: 12pt"></span>&nbsp;</p>  <p><span style="FONT-SIZE: 12pt">중국 방문자와 중국 출신 요양병원 종사자 조사도 마쳤습니다.</span><br>  <span style="FONT-SIZE: 12pt">간병인으로 근무하는 중국인 종사자 277명 중 중국 우한시 출신은 없었으며 중국 명절인 춘절기간 동안 중국을 방문한 사람은 없었습니다. 1월 중에 OOO으로 온 중국인 취업자 1명은 잠복기가 지나는 동안 별다른 증상이 없음을 확인했습니다.</span></p>  <p><span style="FONT-SIZE: 12pt"></span>&nbsp;</p>  <p><span style="FONT-SIZE: 12pt">신종 코로나로 요동칠 수 있는 지역경제를 위해 물가대책반이 가동되고 있으며 환경오염을 막고자 추진하고 있던 음식점 1회용품 사용규제 조치를 완화했습니다.</span></p>  <p><span style="FONT-SIZE: 12pt"></span>&nbsp;</p>  <p><span style="FONT-SIZE: 12pt">이밖에 대부분 행사와 평생학습 관련 각종 강의 프로그램, 생활체육 프로그램도 중단했습니다.</span></p>  <p><span style="FONT-SIZE: 12pt">신종 코로나 확산 방지를 위해 OOO구는 최선을 다하겠습니다.</span></p>  <p><span style="FONT-SIZE: 12pt"></span>&nbsp;</p>  <p><span style="FONT-SIZE: 12pt">현재까지 확진자가 없었던 것은 OOO구민들께서 스스로 위생수칙을 준수하고 능동감시 신고 등 행정을 믿고 따라와주셨기 때문이라고 생각합니다.</span></p>  <p><span style="FONT-SIZE: 12pt">지금까지 하셨듯이 </span><span style="FONT-SIZE: 12pt">마스크 착용과 수시로 손을 닦는 것을 강력하게 권해드립니다.</span></p>  <p><span style="FONT-SIZE: 12pt"></span>&nbsp;</p>  <p><span style="FONT-SIZE: 12pt">혹시 열이 나거나 기침, 인후통이 있으시다면 바로 병원으로 가지 마시고, 1339로 전화해 상담부터 받으셔야 혹시라도 있을 제2, 제3의 확산을 막을 수 있습니다. </span></p>  <p><span style="FONT-SIZE: 12pt">앞으로도 가감 없이, 있는 그대로 신종 코로나바이러스 감염증 상황을 OOO 구민들께 알려 드리겠습니다.</span></p>  <p><span style="FONT-SIZE: 12pt"></span>&nbsp;</p>  <p><span style="FONT-SIZE: 12pt">늘 그랬듯이 우리는 이겨낼 수 있습니다. 저희도 책무를 다하겠습니다.</span><br>  <span style="FONT-SIZE: 12pt">감사합니다.</span><!--StartFragment--></p>')
GO
INSERT Coronavirus_info(contacted_self_isolation, clear_contacted_self_isolation, isolation_cnt, clear_isolation_cnt, self_isolation, clear_self_isolation, offered)
VALUES(306, 336, 914, 7211, 318,866, GETDATE())
GO
INSERT Coronavirus_local(whole_confirmed_cnt, death_cnt, checkup_cnt, negative_cnt, local_confirmed_cnt, confirmd_increase_cnt, local_contacted_cnt, contacted_increase_cnt, local_similar_cnt, similar_increase_cnt, local_self_isolation_cnt, self_isolation_increase_cnt, from_wuhan_cnt, wuhan_increase_cnt, offered)
VALUES(5776, 35, 21810, 118965, 9, 0, 306, 0, 32, 0, 992,0, 7211, 0, GETDATE())
GO
