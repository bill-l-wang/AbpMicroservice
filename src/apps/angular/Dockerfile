FROM node:18-alpine as build

WORKDIR /app
COPY apps/angular/package*.json /app/

RUN npm install
COPY apps/angular/. /app
ARG configuration=production
RUN npm run build -- --output-path=dist/Macro --configuration $configuration

FROM nginx:alpine
COPY apps/angular/dynamic-env.json /usr/share/nginx/html
COPY apps/angular/nginx.conf  /etc/nginx/conf.d/default.conf

COPY --from=build /app/dist/Macro/ /usr/share/nginx/html
