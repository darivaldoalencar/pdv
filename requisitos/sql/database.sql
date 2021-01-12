create database pdvtst;
CREATE USER 'pdvdev'@'%' IDENTIFIED BY 'pdvdev';
GRANT ALL ON pdvtst.* to 'pdvdev'@'%';
