#!/bin/sh
set -e

wait_for(){
    local STARTTIME=$1
    local LOCAL_STARTTIME=$(date +%s)
    local URL=$2
    printf "waiting for $URL."
	until $(curl --output /dev/null --silent --fail $URL); do
		local ENDTIME=$(date +%s)
		local DURATION=$(($ENDTIME - $STARTTIME))

		if [ $DURATION -gt 180 ] ; then
			echo "TIMEOUT"
			exit 1
		fi

		printf '.'
		sleep 1
	done
	local ENDTIME=$(date +%s)
	local DURATION=$(($ENDTIME - $LOCAL_STARTTIME))
	echo "OK ($DURATION s)"
}

wait_for_start(){
	local STARTTIME=$(date +%s)
	wait_for $STARTTIME "http://localhost:9000/minio/health/live" "GET"
}

start_system() {
	/bin/sh -e -c "set -e; docker-compose -f -d /src/ReportPortal/docker-compose.yaml"
	wait_for_start
	/bin/sh -e -c "set -e; dotnet test RomanAparin.ApiTests.dll -c Release --no-build"
    fi
}

start_system