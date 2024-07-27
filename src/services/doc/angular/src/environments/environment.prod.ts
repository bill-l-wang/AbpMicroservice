import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44304/',
  redirectUri: baseUrl,
  clientId: 'DocService_App',
  responseType: 'code',
  scope: 'offline_access DocService',
  requireHttps: true,
};

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'DocService',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44304',
      rootNamespace: 'DocService',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
  remoteEnv: {
    url: '/getEnvConfig',
    mergeStrategy: 'deepmerge'
  }
} as Environment;
