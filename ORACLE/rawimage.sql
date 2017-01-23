CREATE TABLE rawimage (
  rawimageid char(38) NOT NULL,
  changestamp DATE   DEFAULT (sysdate),
  computername varchar2(64) DEFAULT NULL,
  fname varchar(255) DEFAULT NULL,
  filetype varchar2(40) DEFAULT NULL,
  link1part varchar2(64) DEFAULT NULL,
  link1id char(38) DEFAULT NULL,
  link2part varchar2(64) DEFAULT NULL,
  link2id char(38) DEFAULT NULL,
  image blob,
  oper char(38) DEFAULT NULL,
  PRIMARY KEY (rawimageid)
) 
