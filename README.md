Unity.WebAPI
===================

이 프로젝트는 UNITY와 ASP.CORE를 이용한 게임개발 행사에 사용되며
RESTFul HTTP로 랭킹을 추가하고 보여주는 샘플입니다.

----------


시작
-------------
샘플 프로젝트를 동작시키기 위해서는  MySQL 데이터베이스가 필요합니다. `appsettings.json`파일의 DefaultConnection에 데이베이스 연결 문자열을 입력해주셔야합니다.

코드 수정 없이 작동을 보려면 `ranktbl`이름으로 된 테이블이 필요하며 MySql.Data 패키지를 설치해주셔야 합니다.

```
-- ranktbl 테이블을 만드는 SQL입니다.
CREATE TABLE `<databaseName>`.`ranktbl` 
( 
 `nickname` VARCHAR(120) NOT NULL, 
 `score` INT NULL,  PRIMARY KEY (`nickname`)
)
ENGINE = InnoDB DEFAULT
CHARACTER SET = utf8;
```
