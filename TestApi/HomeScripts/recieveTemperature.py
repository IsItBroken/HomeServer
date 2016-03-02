import serial
import requests
import json

ser = serial.Serial('/dev/ttyAMA0', 9600, timeout=1)
ser.write("connected")

url = 'http://zachdesktop:5050'
headers = {'content-type': 'application/json'}
try:
	while 1:
		response = ser.readline().rstrip()
		if response:
			print response
			values = response.split(',')
			
			out = ('{{"temperature": "{0}", "humidity": "{1}", "heatIndex": "{2}"}}').format(values[0], values[1], values[2])
			print out
			response = requests.post(url + '/api/temperature', data = out, headers = headers)
except KeyboardInterrupt:
	ser.close()