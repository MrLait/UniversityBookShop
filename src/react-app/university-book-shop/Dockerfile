FROM node:20.11.0
WORKDIR /app
COPY . .
RUN npm ci
RUN npm run lint
RUN npm run build
CMD [ "npm", "start" ]
