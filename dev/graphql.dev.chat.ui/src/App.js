import * as React from "react";
import { Provider } from "react-redux";
import { store, Playground } from "graphql-playground-react";
import { TankaClient, TankaLink } from "@tanka/tanka-graphql-server-link";
import { RetryLink } from "apollo-link-retry";
import { ApolloLink } from 'apollo-link';

const client = new TankaClient('https://localhost:5000/graphql', {});
const tankaLink = new TankaLink(client);

const link = ApolloLink.from([
  new RetryLink(),
  tankaLink
]);

const settings  = {
  'editor.cursorShape': 'line', // possible values: 'line', 'block', 'underline'
  'editor.fontFamily': `'Source Code Pro', 'Consolas', 'Inconsolata', 'Droid Sans Mono', 'Monaco', monospace`,
  'editor.fontSize': 14,
  'editor.reuseHeaders': true, // new tab reuses headers from last tab
  'editor.theme': 'dark', // possible values: 'dark', 'light'
  'general.betaUpdates': false,
  'prettier.printWidth': 80,
  'prettier.tabWidth': 2,
  'prettier.useTabs': false,
  'request.credentials': 'omit', // possible values: 'omit', 'include', 'same-origin'
  'schema.polling.enable': true, // enables automatic schema polling
  'schema.polling.endpointFilter': '*', // endpoint filter for schema polling
  'schema.polling.interval': 10000, // schema polling interval in ms
  'schema.disableComments': false,
  'tracing.hideTracingResponse': true,
};

class Home extends React.Component {
  createLink = (session) => {
    return {
      link: link
    };
  };

  render() {
    return (
      <Provider store={store}>
        <Playground createApolloLink={this.createLink} settings={settings} />
      </Provider>
    );
  }
}

export default Home;