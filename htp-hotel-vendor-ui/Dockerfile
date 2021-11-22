# pull the base image
FROM node:alpine

# set the working direction
WORKDIR /app

RUN chgrp -R 0 /app && chmod -R g=u /app

# add `/app/node_modules/.bin` to $PATH
ENV PATH /app/node_modules/.bin:$PATH

# install app dependencies
COPY package.json ./

COPY package-lock.json ./

RUN npm install

ARG REACT_APP_BACKEND_HOST
ARG REACT_APP_BACKEND_BOOKING_RESOURCE
ARG REACT_APP_VENDOR_TYPE

ENV REACT_APP_BACKEND_HOST $REACT_APP_BACKEND_HOST
ENV REACT_APP_BACKEND_BOOKING_RESOURCE $REACT_APP_BACKEND_BOOKING_RESOURCE
ENV REACT_APP_VENDOR_TYPE $REACT_APP_VENDOR_TYPE

# add app
COPY . ./

RUN chgrp -R 0 /app && chmod -R g=u /app

# start app
CMD ["npm", "start"]