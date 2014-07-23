import time

#collects data from sensor.txt and pushes it to a local CSV file.


PATH = '/home/pi/skyrise/data/'

def readPressure():

    try:
        file = open(PATH+"Pressure.txt")
        data = file.readline()
        file.close()
    except:
        return
    return data
            
def readGps():
    try:
        file = open(PATH+"Gps.txt")
        data = file.readline()
        file.close()
    except:
        return
    return data            
            
def readHumidity():
    try:
        file = open(PATH+"Humidity.txt")
        data = file.readline()
        file.close()
    except:
        return
    return data                  

def getData():
    datastring = ""
    
    #adding Pressure and temperatur
    Pressuredata = readPressure()
    if(Pressuredata != None):
        datastring += Pressuredata
    else:
        datastring += ",,"
    
    #adding GPS data = Sat-time,lat,lon,alt
    
        GPSdata = readGps()
    if(GPSdata != None):
        datastring += ","+GPSdata
    else:
        datastring += ",,,,,"
        
    #adding Humidity: realtive humidity, tempeature.
    
    HumidityData = readHumidity()
    if(HumidityData != None):
        datastring += ","+HumidityData
    else:
        datastring += ",,,"
        
    return datastring 

def appendRow(Row): #appends a row of telemetry to local CSV file
    f = open("DB.csv")
    if(f.readline() != None):
        f.write("Pressure,Temperature,sat-time,lat,lon,alt,relHum,temperatur\n")
    else:
        f.write(Row+"\n")
    f.close()
    return


while(True):
    row = getData()
    appendRow(row)
    time.sleep(1000)  #is it in milliseconds
    
