import * as React from "react";
import { Admin, Resource } from 'react-admin';
import fetchService from './services/fetchService';
import { EmployList, EmployEdit, EmployCreate } from './components/employ/EmployCrud'
import { SkillList, SkillEdit, SkillCreate } from './components/skill/SkillCrud'

const App = () => (
    <Admin dataProvider={fetchService} >
        <Resource name="employ" list={EmployList} edit={EmployEdit} create={EmployCreate} />
        <Resource name="skill" list={SkillList} edit={SkillEdit} create={SkillCreate} />
    </Admin >
);

export default App;