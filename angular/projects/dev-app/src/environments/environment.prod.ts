import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'Forum',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44379',
    redirectUri: baseUrl,
    clientId: 'Forum_App',
    responseType: 'code',
    scope: 'offline_access Forum',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44379',
      rootNamespace: 'EasyAbp.Forum',
    },
    Forum: {
      url: 'https://localhost:44395',
      rootNamespace: 'EasyAbp.Forum',
    },
  },
} as Environment;
