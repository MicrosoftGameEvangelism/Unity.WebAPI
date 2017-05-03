Unity.WebAPI
===================

이 프로젝트는 UNITY와 ASP.CORE를 이용한 게임개발 행사에 사용되며
RESTFul HTTP로 랭킹을 추가하고 보여주는 샘플입니다.

----------


시작
-------------
샘플 프로젝트를 동작시키기 위해서는 MySQL 데이터베이스가 필요합니다. `appsettings.json`파일의 `DefaultConnection`에 데이베이스 연결 문자열을 입력해주셔야합니다. Azure를 이용하면 손쉽고 빠르게 MySQL 데이터베이스를 만들고 테스트 해볼 수 있습니다.

코드 수정 없이 확인해 보려면 `ranktbl`이름으로 된 테이블이 필요하며 프로젝트로 부터 데이터베이스에 연결하기 위해서 MySql.Data 패키지를 설치해주셔야 합니다. .NET 프로젝트에 패키지를 설치하기 위해서는 Nuget패키지관리자를 이용하시면 됩니다. (설치가 되었는지 확인하기 위해서 종속성 > Nuget을 확인해보세요.)

``` SQL
-- ranktbl 테이블을 만드는 SQL입니다.
CREATE TABLE `<databaseName>`.`ranktbl` 
( 
 `nickname` VARCHAR(120) NOT NULL, 
 `score` INT NULL,  PRIMARY KEY (`nickname`)
)
ENGINE = InnoDB DEFAULT
CHARACTER SET = utf8;
```
MySqlConnection
-------------
``` C#
using(MySqlConnection conn = new MySqlConnection(ConnectionString))
{
 //MySqlCommand Code...
}
```

MySqlCommand
-------------

### SELECT
ranktbl의 SCORE를 역순(descending)정렬하여 출력하는 커맨드입니다.
``` C#
MySqlCommand command = new MySqlCommand("SELECT * FROM ranktbl ORDER BY SCORE DESC", conn);
using(MySqlDataReader reader = command.ExecuteReader())
{
  while(reader.Read())
  {
    list.Nickname = reader.GetString("nickname");
    list.Score = reader.GetInt32("score"); 
  }
}
```
### INSERT
ranktbl에 데이터 삽입(INSERT)하는 커맨드입니다.
``` C#
MySqlCommand command = new MySqlCommand("INSERT ranktbl(nickname, score) VALUES(@nickname, @score)", conn);
command.Parameters.Add("@nickname", MySqlDbType.String);
command.Parameters.Add("@score", MySqlDbType.Int32);
command.Parameters["@nickname"].Value = nickname.ToString();
command.Parameters["@score"].Value = score;
command.ExcuteNonQuery();
```
