#!/bin/bash
if [ ! -d "/home/coder/project/workspace/dotnetproject/" ]
then
    cp -r /home/coder/project/workspace/nunit/dotnetproject/ /home/coder/project/workspace/dotnetproject/;
fi
 
if [ ! -d "/home/coder/project/workspace/dotnetproject/dotnetapiapp" ]
then
    cp -r /home/coder/project/workspace/nunit/dotnetproject/dotnetapiapp/ /home/coder/project/workspace/dotnetproject/dotnetapiapp/;
fi
 
if [ ! -d "/home/coder/project/workspace/dotnetproject/dotnetmvcapp" ]
then
    cp -r /home/coder/project/workspace/nunit/dotnetproject/dotnetmvcapp/ /home/coder/project/workspace/dotnetproject/dotnetmvcapp/;
fi

if [ -d "/home/coder/project/workspace/dotnetproject/" ]
then
    echo "project folder present"
    # checking for src folder
    if [ -d "/home/coder/project/workspace/dotnetproject/" ]
    then
        cp -r /home/coder/project/workspace/nunit/test/TestProject /home/coder/project/workspace/dotnetproject/;
    cd /home/coder/project/workspace/dotnetproject/TestProject || exit;
     dotnet clean;    
     dotnet test;
    else
        echo "JoinRide_ValidCommuter_JoinsSuccessfully FAILED";
        echo "JoinRide_ValidCommuter_JoinsSuccessfully2 FAILED";
	    echo "JoinRide_ValidCommuter_JoinsSuccessfully3 FAILED";
        echo "JoinRide_ValidCommuter_JoinsSuccessfully1 FAILED";
        echo "JoinRide_RideNotFound_ReturnsNotFoundResult FAILED";
        echo "JoinRide_MaximumCapacityReached_ThrowsException FAILED";
        echo "JoinRide_MaximumCapacityReached_ThrowsExceptionwith_message FAILED";
        echo "RideClassExists FAILED";
        echo "CommuterClassExists FAILED";
        echo "ApplicationDbContextContainsDbSetSlotProperty FAILED";
        echo "ApplicationDbContextContainsDbSetBookingProperty FAILED";
        echo "Commuter_Properties_CommuterID_ReturnExpectedDataTypes FAILED";
        echo "Commuter_Properties_Name_ReturnExpectedDataTypes FAILED";
        echo "Commuter_Properties_Email_ReturnExpectedDataTypes FAILED";
        echo "Commuter_Properties_Phone_ReturnExpectedDataTypes FAILED";
        echo "Commuter_Properties_RideID_ReturnExpectedDataTypes FAILED";
        echo "Ride_Properties_RideID_ReturnExpectedDataTypes FAILED";
        echo "Ride_Properties_DepartureLocation_ReturnExpectedDataTypes FAILED";
        echo "Ride_Properties_Destination_ReturnExpectedDataTypes FAILED";
        echo "Ride_Properties_DateTime_ReturnExpectedDataTypes FAILED";
        echo "Ride_Properties_MaximumCapacity_ReturnExpectedDataTypes FAILED";
        echo "Commuter_Ride_ReturnsExpectedValue FAILED";
        echo "Commuter_Properties_CommuterID_ReturnExpectedValues FAILED";
        echo "Commuter_Properties_Name_ReturnExpectedValues FAILED";
        echo "Commuter_Properties_Email_ReturnExpectedValues FAILED";
        echo "Commuter_Properties_Phone_ReturnExpectedValues FAILED";
        echo "Commuter_Properties_RideID_ReturnExpectedValues FAILED";
    fi
else   
    echo "JoinRide_ValidCommuter_JoinsSuccessfully FAILED";
    echo "JoinRide_ValidCommuter_JoinsSuccessfully2 FAILED";
	echo "JoinRide_ValidCommuter_JoinsSuccessfully3 FAILED";
    echo "JoinRide_ValidCommuter_JoinsSuccessfully1 FAILED";
    echo "JoinRide_RideNotFound_ReturnsNotFoundResult FAILED";
    echo "JoinRide_MaximumCapacityReached_ThrowsException FAILED";
    echo "JoinRide_MaximumCapacityReached_ThrowsExceptionwith_message FAILED";
    echo "RideClassExists FAILED";
    echo "CommuterClassExists FAILED";
    echo "ApplicationDbContextContainsDbSetSlotProperty FAILED";
    echo "ApplicationDbContextContainsDbSetBookingProperty FAILED";
    echo "Commuter_Properties_CommuterID_ReturnExpectedDataTypes FAILED";
    echo "Commuter_Properties_Name_ReturnExpectedDataTypes FAILED";
    echo "Commuter_Properties_Email_ReturnExpectedDataTypes FAILED";
    echo "Commuter_Properties_Phone_ReturnExpectedDataTypes FAILED";
    echo "Commuter_Properties_RideID_ReturnExpectedDataTypes FAILED";
    echo "Ride_Properties_RideID_ReturnExpectedDataTypes FAILED";
    echo "Ride_Properties_DepartureLocation_ReturnExpectedDataTypes FAILED";
    echo "Ride_Properties_Destination_ReturnExpectedDataTypes FAILED";
    echo "Ride_Properties_DateTime_ReturnExpectedDataTypes FAILED";
    echo "Ride_Properties_MaximumCapacity_ReturnExpectedDataTypes FAILED";
    echo "Commuter_Ride_ReturnsExpectedValue FAILED";
    echo "Commuter_Properties_CommuterID_ReturnExpectedValues FAILED";
    echo "Commuter_Properties_Name_ReturnExpectedValues FAILED";
    echo "Commuter_Properties_Email_ReturnExpectedValues FAILED";
    echo "Commuter_Properties_Phone_ReturnExpectedValues FAILED";
    echo "Commuter_Properties_RideID_ReturnExpectedValues FAILED";
fi