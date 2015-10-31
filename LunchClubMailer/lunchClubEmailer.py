#!/usr/bin/python
""" lunchClubMailer.py: randomly assigns list to groups and emails"""
__author__ = "Bailey Mader"
__copyright__ = "Copyright 2013, Bailey Mader"
__credits__ = ""
__license__ = "GPL"
__version__ = "0.0.1"
__status__ = "Development"

import random
import smtplib
import os
import time

# and the default "lunchclub string"
fromEmail = 'PioneerYoungProfessionals@pioneer.com'
organizerEmail = 'bailey.mader@pioneer.com;heidi.cline@pioneer.com;' + fromEmail
subject = 'PYP Lunch Club'
body = '\nThis is your lunch group for the PYP Lunch Club this month.'
body += '\n\nThe person at the top of this list is the organizer and should schedule a meeting for the group and propose a place to eat.'
body += '\nIf this hasn\'t been done within 3 work days, the second person on the list should step in as organizer. \n\nHappy networking!\n\n'
etiquette = '\n\nLunch Club Etiquette:'
etiquette += '\nPlease accept or decline your lunch club invitation so the organizer knows who to expect.'
etiquette += '\nIf you have to cancel, please let the organizer know your change in plans.'
etiquette += '\nOn the day of the lunch meeting, the organizer should touch base with everyone to re-confirm who is attending and who is not.'

organizerBody = 'Groups For This Month \n\n-----------------------------\n'

def createEmailXML(ls):
        #start the xml
        xml = '<EMAIL>\n<TO>\n'
        #add the email addresses
        for s in ls:
                xml += s[:s.find(',')] + ';'
        #add the from, subject, and body
        xml += '</TO>\n<FROM>' + fromEmail + '</FROM>\n<SUBJECT>' + subject + '</SUBJECT>\n<BODY>\n'
        xml += body
        #add the names to the body
        for s in ls:
                xml += s[s.find(',')+1:] + '\n'
        
        #finish off the xml
        xml += etiquette + '\n'
        xml += '</BODY>\n</EMAIL>'
        #print(xml)
        return xml

def createOrganizerEmail(ls):
        ob = ''
        for s in ls:
                ob += s[s.find(',')+1:] + '\n'
        ob += '-----------------------------\n'
        return ob

#open the file with the names and emails
#first string is the email address, all following strings are the name
fo = open('namesAndEmails.csv', 'r')
text = fo.read()
fo.close()
textList = text.splitlines()
listLen = len(textList)
random.shuffle(textList)
random.shuffle(textList)

#check that remainder >3 and adjust group size
rem = listLen % 5
numgrps = int(listLen / 5)

if numgrps == 0: #take care of < 5
	numgrps = 1
	rem = 0
if rem == 4: #there gets to be one small group
	numgrps += 1
	rem = 0
if rem >= 0 and rem <= 3 and rem > numgrps: #take care of 7, 8, and 13 #FIX!!!!!
	numgrps += 1
	rem -= 1

#chunk the list
#go by 6 for each of the remainders
foldername = "PYPLunchClub_" + str(time.localtime().tm_year) + str(time.localtime().tm_mon) + str(time.localtime().tm_mday) + str(time.localtime().tm_hour) + str(time.localtime().tm_min) + str(time.localtime().tm_sec)

for num in range(0, rem):
        os.mkdir(foldername + str(num))
        file = open(foldername + str(num) + "\config.xml", 'w')
        file.write(createEmailXML(textList[-6:]))
        organizerBody += createOrganizerEmail(textList[-6:])
        file.close()
        del textList[-6:]

#go by 5 from then on
#last one should just be whatever is left over 
#(3 when 7, 8, 13; 4 when extra group was added; 5 otherwise)
for num in range(0, numgrps - rem):
        os.mkdir(foldername + str(num+10))
        file = open(foldername + str(num+10) + "\config.xml", 'w')
        file.write(createEmailXML(textList[-5:])) #slicing like this truncates if you go out of index, so if there's less than five, it won't break
        organizerBody += createOrganizerEmail(textList[-5:])
        file.close()
        del textList[-5:]

#start the xml
orgxml = '<EMAIL>\n<TO>'
#add the email addresses
orgxml += organizerEmail
#add the from, subject, and body
orgxml += '</TO>\n<FROM>' + fromEmail + '</FROM>\n<SUBJECT>' + subject + '</SUBJECT>\n<BODY>\n'
orgxml += organizerBody

#finish off the xml
orgxml += '</BODY>\n</EMAIL>'
os.mkdir(foldername)
file = open(foldername + "\config.xml", 'w')
file.write(orgxml)
file.close();




