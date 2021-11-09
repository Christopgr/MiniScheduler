import * as React from "react";
import { List, Datagrid, NumberField, TextField, ArrayField, AutocompleteArrayInput, SingleFieldList, ChipField, EmailField, DateField, Edit, SimpleForm, TextInput, Create, ReferenceInput, SelectInput } from 'react-admin';

const employFilters = [
    <TextInput source="q" label="Search" alwaysOn />,
    <ReferenceInput source="employ" label="Employ" reference="employ" allowEmpty>
        <SelectInput optionText="name" />
    </ReferenceInput>,
];

export const EmployList = props => (
    <List filters={employFilters} {...props}>
        <Datagrid rowClick="edit">
            <NumberField source="id" />
            <TextField source="name" />
            <TextField source="surname" />
            <TextField source="telephone" />
            <EmailField source="email" />
            <DateField source="created" />
            <DateField source="updated" />
            <ArrayField source="skills">
                <SingleFieldList>
                    <ChipField source="name" />
                </SingleFieldList>
            </ArrayField>

        </Datagrid>
    </List>
);

export const EmployEdit = props => {

    const [skillsList, setSkills] = React.useState([]);
    React.useEffect(() => {
        fetch(
            `https://localhost:7213/api/skill`,
            {
                method: "GET",
                headers: new Headers({
                    Accept: "application/json"
                })
            }
        )
            .then(res => res.json())
            .then(data => setSkills(data))
            .catch(error => console.log(error));
    }, []);

    return (
        <Edit {...props}>
            <SimpleForm>
                <NumberField disabled source="id" />
                <TextInput source="name" />
                <TextInput source="surname" />
                <TextInput source="telephone" />
                <TextInput source="email" />
                <AutocompleteArrayInput
                    parse={value => value && value.map(v => skillsList.find(x => x.id = v))
                    }
                    format={value => value && value.map(v => v.id)}
                    source="skills" choices={skillsList}
                />
            </SimpleForm>
        </Edit>
    );
}

export const EmployCreate = props => {

    const [skillsList, setSkills] = React.useState([]);
    React.useEffect(() => {
        fetch(
            `https://localhost:7213/api/skill`,
            {
                method: "GET",
                headers: new Headers({
                    Accept: "application/json"
                })
            }
        )
            .then(res => res.json())
            .then(data => setSkills(data))
            .catch(error => console.log(error));
    }, []);

    return (
        <Create {...props}>
            <SimpleForm>
                <TextInput source="name" />
                <TextInput source="surname" />
                <TextInput source="telephone" />
                <TextInput source="email" />
                <AutocompleteArrayInput
                    parse={value => value && value.map(v => skillsList.find(x => x.id = v))
                    }
                    format={value => value && value.map(v => v.id)}
                    source="skills" choices={skillsList}
                />
            </SimpleForm>
        </Create>
    );
}