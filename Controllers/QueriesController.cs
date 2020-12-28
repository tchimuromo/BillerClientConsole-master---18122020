﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BillerClientConsole._Globals;
using BillerClientConsole.Data;
using BillerClientConsole.Models;
using BillerClientConsole.Models.QueryModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BillerClientConsole.Controllers
{
    [Route("Queries")]
    public class QueriesController : Controller
    {
        private readonly QueryDbContext context;

        public QueriesController(QueryDbContext context)
        {
            this.context = context;
        }
        [HttpPost("RegisteredOfficeHasQuery")]
        public async Task<IActionResult> RegisteredOfficeHasQuery(Queries query)
        {
            //Code to check if there exist a Query with same ref number
            var QueryExits = context.Queries.Where(q => q.applicationRef == query.applicationRef && q.tableName == "Step2");
            if (QueryExits.Count() > 0)
            {
                if (query.HasQuery == true)
                {
                    //If it exists and has another query Update the current 
                    var queryExists = QueryExits.FirstOrDefault();
                    queryExists.QueryCount += 1;
                    
                    context.Queries.Update(queryExists);
                    await context.SaveChangesAsync();

                    var forqueryhistory = new QueryHistory()
                    {
                        applicationRef = query.applicationRef,
                        comment = query.comment,
                        dateCreated = DateTime.Now.ToString(),
                        status = "Pending",
                        tableName="Step2",
                    };
                    context.QueryHistory.Add(forqueryhistory);
                    await context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    var queryExists = QueryExits.FirstOrDefault();
                    queryExists.status = "Resolved";
                    queryExists.HasQuery = false;
                    context.Queries.Update(queryExists);
                    await context.SaveChangesAsync();
                    //Updating the Query History Table
                    var forqueryhistory = new QueryHistory()
                    {
                        applicationRef = query.applicationRef,
                        comment = query.comment,
                        dateCreated = DateTime.Now.ToString(),
                        status = "Resolved",
                        tableName = "Step2",
                        
                    };
                    context.QueryHistory.Add(forqueryhistory);
                    await context.SaveChangesAsync();
                    return Ok();
                }
            }
            else
            {
                if (query.HasQuery == true)
                {
                    query.status = "Pending";
                    query.dateCreated = DateTime.Now.ToString();
                    query.QueryCount += 1;
                    query.tableName = "Step2";
                    context.Queries.Add(query);
                    await context.SaveChangesAsync();

                    var forqueryhistory = new QueryHistory()
                    {
                        applicationRef = query.applicationRef,
                        comment = query.comment,
                        dateCreated = DateTime.Now.ToString(),
                        status = "Pending",
                        tableName = "Step2",
                    };
                    context.QueryHistory.Add(forqueryhistory);
                    await context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }  
        }
        //ShareClause Query Handling
        [HttpPost("LiabilityAndShareClauseHasQuery")]
        public async Task<IActionResult> ShareClauseHasQuery(Queries query)
        {
            var QueryExits = context.Queries.Where(q => q.applicationRef == query.applicationRef && q.tableName=="Step4");
            if (QueryExits.Count() > 0)
            {
                if (query.HasQuery == true)
                {
                    //If it exists and has another query Update the current 
                    var queryExists = QueryExits.FirstOrDefault();
                    queryExists.QueryCount += 1;

                    context.Queries.Update(queryExists);
                    await context.SaveChangesAsync();

                    var forqueryhistory = new QueryHistory()
                    {
                        applicationRef = query.applicationRef,
                        comment = query.comment,
                        dateCreated = DateTime.Now.ToString(),
                        status = "Pending",
                        tableName = "Step4",
                    };
                    context.QueryHistory.Add(forqueryhistory);
                    await context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    var queryExists = QueryExits.FirstOrDefault();
                    queryExists.status = "Resolved";
                    queryExists.HasQuery = false;
                    context.Queries.Update(queryExists);
                    await context.SaveChangesAsync();
                    //Updating the Query History Table
                    var forqueryhistory = new QueryHistory()
                    {
                        applicationRef = query.applicationRef,
                        comment = query.comment,
                        dateCreated = DateTime.Now.ToString(),
                        status = "Resolved",
                        tableName = "Step4",

                    };
                    context.QueryHistory.Add(forqueryhistory);
                    await context.SaveChangesAsync();
                    return Ok();
                }
            }
            else
            {
                if (query.HasQuery == true)
                {
                    query.status = "Pending";
                    query.dateCreated = DateTime.Now.ToString();
                    query.QueryCount += 1;
                    query.tableName = "Step4";
                    context.Queries.Add(query);
                    await context.SaveChangesAsync();

                    var forqueryhistory = new QueryHistory()
                    {
                        applicationRef = query.applicationRef,
                        comment = query.comment,
                        dateCreated = DateTime.Now.ToString(),
                        status = "Pending",
                        tableName = "Step4",
                    };
                    context.QueryHistory.Add(forqueryhistory);
                    await context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        [HttpPost("MembersHasQuery")]
        public async Task<IActionResult> MembersHasQuery(Queries query)
        {
            var QueryExits = context.Queries.Where(q => q.applicationRef == query.applicationRef && q.tableName == "Step3");
            if (QueryExits.Count() > 0)
            {
                if (query.HasQuery == true)
                {
                    //If it exists and has another query Update the current 
                    var queryExists = QueryExits.FirstOrDefault();
                    queryExists.QueryCount += 1;

                    context.Queries.Update(queryExists);
                    await context.SaveChangesAsync();

                    var forqueryhistory = new QueryHistory()
                    {
                        applicationRef = query.applicationRef,
                        comment = query.comment,
                        dateCreated = DateTime.Now.ToString(),
                        status = "Pending",
                        tableName = "Step3",
                    };
                    context.QueryHistory.Add(forqueryhistory);
                    await context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    var queryExists = QueryExits.FirstOrDefault();
                    queryExists.status = "Resolved";
                    queryExists.HasQuery = false;
                    context.Queries.Update(queryExists);
                    await context.SaveChangesAsync();
                    //Updating the Query History Table
                    var forqueryhistory = new QueryHistory()
                    {
                        applicationRef = query.applicationRef,
                        comment = query.comment,
                        dateCreated = DateTime.Now.ToString(),
                        status = "Resolved",
                        tableName = "Step3",

                    };
                    context.QueryHistory.Add(forqueryhistory);
                    await context.SaveChangesAsync();
                    return Ok();
                }
            }
            else
            {
                if (query.HasQuery == true)
                {
                    query.status = "Pending";
                    query.dateCreated = DateTime.Now.ToString();
                    query.QueryCount += 1;
                    query.tableName = "Step3";
                    context.Queries.Add(query);
                    await context.SaveChangesAsync();

                    var forqueryhistory = new QueryHistory()
                    {
                        applicationRef = query.applicationRef,
                        comment = query.comment,
                        dateCreated = DateTime.Now.ToString(),
                        status = "Pending",
                        tableName = "Step3",
                    };
                    context.QueryHistory.Add(forqueryhistory);
                    await context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
        }
    }
}