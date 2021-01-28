<template>
    <v-container  app>
        <v-row style="margin-top: 50px">
         <v-col cols="12">
        <h2>Welcome to SCENt!</h2>
        </v-col>
        </v-row>
        <v-row justify="center">
        <v-col cols="12">
        <div style="width:600px">The goal of the SCENt applicaiton is to support eliciation of non-functional requirements.
            Based on some information about your project you provide SCENt suggests you the templates of
            non-functional requirements that you might find useful when specifing requirements.
        </div>

        <h4 style="margin-top: 50px">Do not waste your time and start elicitation!</h4>
        </v-col>
        </v-row>
        <v-row style="margin-top: 30px">
            <v-col>
        <v-btn to="/Projects" color="primary">Start!</v-btn>
        </v-col>
        </v-row>

    </v-container>
</template>
<script>
export default {
}
</script>
