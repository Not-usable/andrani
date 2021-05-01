FROM mcr.microsoft.com/mssql/server:2019-latest

ENV MSSQL_PID Express

COPY ./initiate.sql .
COPY ./entrypoint.sh .

CMD /bin/bash ./entrypoint.sh